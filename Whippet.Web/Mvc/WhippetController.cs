using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using NodaTime;
using __File = System.IO.File;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.Security;

namespace Athi.Whippet.Web.Mvc
{
    /// <summary>
    /// A base class for an MVC controller with view support in Whippet. This class must be inherited.
    /// </summary>
    /// <typeparam name="TController"><see cref="Controller"/> type.</typeparam>
    public abstract class WhippetController<TController> : Controller
    {
        private const string CONFIG_SECTION_TENANT = "WhippetRootTenant";
        private const string CONFIG_SECTION_TENANT__ID = "Id";
        private const string CONFIG_SECTION_TENANT__NAME = "Name";
        private const string CONFIG_SECTION_TENANT__URL = "Url";

        private IWhippetTenant _currentTenant;

        /// <summary>
        /// Gets the logging mechanism for the current controller. This property is read-only.
        /// </summary>
        protected virtual ILogger<TController> Logger
        { get; private set; }

        /// <summary>
        /// Gets the current configuration that was injected into the controller from the caller. This property is read-only.
        /// </summary>
        protected virtual IConfiguration Configuration
        { get; private set; }

        /// <summary>
        /// Gets the root <see cref="WhippetTenant"/> that serves as the host for the application. This property is read-only.
        /// </summary>
        protected virtual WhippetTenant RootTenant
        {
            get
            {
                return WhippetTenant.Root.ToWhippetTenant();
            }
        }

        /// <summary>
        /// Gets the current <see cref="CultureInfo"/> as specified by the HTTP request. If the <see cref="CultureInfo"/> could not be loaded, <see cref="CultureInfo.InvariantCulture"/> will be used. This property is read-only.
        /// </summary>
        public CultureInfo BrowserCulture
        {
            get
            {
                CultureInfo requestedCulture = null;

                try
                {
                    requestedCulture = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.UICulture;
                }
                catch
                {
                    requestedCulture = CultureInfo.InvariantCulture;
                }

                return requestedCulture;
            }
        }

        /// <summary>
        /// Gets or sets the current <see cref="ITokenService"/> used for authentication.
        /// </summary>
        protected virtual ITokenService TokenService
        { get; set; }

        /// <summary>
        /// Gets or sets the current <see cref="IWhippetTenant"/>. If a value of <see langword="null"/> is assigned, will default to <see cref="RootTenant"/>.
        /// </summary>
        protected virtual IWhippetTenant CurrentTenant
        {
            get
            {
                if (_currentTenant == null)
                {
                    _currentTenant = RootTenant;
                }

                return _currentTenant;
            }
            set
            {
                _currentTenant = value;
            }
        }

        /// <summary>
        /// Gets the IP address of the requesting client (if available). This property is read-only.
        /// </summary>
        protected virtual string ClientIpAddress
        {
            get
            {
                return HttpContext.Connection.RemoteIpAddress?.ToString();
            }
        }

        /// <summary>
        /// Gets the IP address of the hosting server (if available). This property is read-only.
        /// </summary>
        protected virtual string ServerIpAddress
        {
            get
            {
                return HttpContext.Features.Get<IHttpConnectionFeature>()?.LocalIpAddress?.ToString();
            }
        }

        /// <summary>
        /// Gets the directory of the current assembly. This property is read-only.
        /// </summary>
        protected virtual string AssemblyDirectory
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        /// <summary>
        /// Gets the current timestamp as an <see cref="Instant"/> constructed from a UTC <see cref="DateTime"/>. This property is read-only.
        /// </summary>
        protected virtual Instant UtcTimestamp
        {
            get
            {
                return GetCurrentUtcTime();
            }
        }

        /// <summary>
        /// Gets the current timestamp as a <see cref="DateTime"/> which represents the server's current time. This property is read-only.
        /// </summary>
        protected virtual DateTime ServerTimestamp
        {
            get
            {
                return DateTime.Now;
            }
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetController{TController}"/> class with no arguments.
        /// </summary>
        protected WhippetController()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetController{TController}"/> class with the specified logger and configuration accessor.
        /// </summary>
        /// <param name="logger">Logging mechanism for the current controller.</param>
        /// <param name="configuration">Configuration instance that was supplied by the caller.</param>
        /// <param name="tokenService">Token service to use.</param>
        protected WhippetController(ILogger<TController> logger, IConfiguration configuration, ITokenService tokenService)
            : this()
        {
            Logger = logger;
            Configuration = configuration;
            TokenService = tokenService;

            ConfigureRootTenant();
        }

        /// <summary>
        /// Gets the specified connection string value from the configuration.
        /// </summary>
        /// <param name="connectionStringName">Name of the connection string.</param>
        /// <returns>Connection string value (if found).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string GetConnectionString(string connectionStringName)
        {
            if(String.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new ArgumentNullException(nameof(connectionStringName));
            }
            else
            {
                return Configuration?.GetConnectionString(connectionStringName);
            }
        }

        /// <summary>
        /// Serializes the specified object to JSON.
        /// </summary>
        /// <param name="value">Object to serialize.</param>
        /// <returns>JSON string that represents the supplied object.</returns>
        protected virtual string SerializeObjectToJson(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Gets the current UTC time.
        /// </summary>
        /// <returns><see cref="Instant"/> configured with the current <see cref="DateTime.UtcNow"/> value.</returns>
        protected Instant GetCurrentUtcTime()
        {
            return GetCurrentUtcTime(0, 0, 0, 0, 0, 0, 0);
        }

        /// <summary>
        /// Gets the current UTC time with the specified offsets added or subtracted.
        /// </summary>
        /// <param name="years">Number of years to offset.</param>
        /// <param name="months">Number of months to offset.</param>
        /// <param name="days">Number of days to offset.</param>
        /// <param name="hours">Number of hours to offset.</param>
        /// <param name="minutes">Number of minutes to offset.</param>
        /// <param name="seconds">Number of seconds to offset.</param>
        /// <param name="milliseconds">Number of milliseconds to offset.</param>
        /// <returns><see cref="Instant"/> object.</returns>
        protected Instant GetCurrentUtcTime(int years, int months, int days, int hours, int minutes, int seconds, double milliseconds)
        {
            DateTime utc = DateTime.UtcNow;

            utc = utc.AddYears(years);
            utc = utc.AddMonths(months);
            utc = utc.AddDays(days);
            utc = utc.AddHours(hours);
            utc = utc.AddMinutes(minutes);
            utc = utc.AddSeconds(seconds);
            utc = utc.AddMilliseconds(milliseconds);

            return Instant.FromDateTimeUtc(utc);
        }

        /// <summary>
        /// Determines if the specified <see cref="IActionResult"/> is a <see cref="ForbidResult"/> object.
        /// </summary>
        /// <param name="result"><see cref="IActionResult"/> object to check.</param>
        /// <returns><see langword="true"/> if the <see cref="IActionResult"/> is a <see cref="ForbidResult"/> object; otherwise, <see langword="false"/>.</returns>
        protected virtual bool IsForbidden(IActionResult result)
        {
            return result is ForbidResult;
        }

        /// <summary>
        /// Searches <see cref="Configuration"/> for the specified key (delimited by ':') and returns the value, if found.
        /// </summary>
        /// <param name="key">JSON object key to search for (delimited by ':').</param>
        /// <returns>Value of the entry or <see cref="String.Empty"/> if not found or no value present.</returns>
        /// <exception cref="ArgumentNullException" />
        public string SearchConfiguration(string key)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            else
            {
                string returnValue = String.Empty;

                if (Configuration != null)
                {
                    returnValue = (from c in Configuration.AsEnumerable() where String.Equals(c.Key, key, StringComparison.InvariantCultureIgnoreCase) select c.Value).FirstOrDefault();
                }

                return returnValue;
            }
        }

        /// <summary>
        /// Saves all files contained in the <see cref="HttpContext.Request"/> to a temporary directory on the server and returns an <see cref="IReadOnlyList{T}"/> containing a <see cref="Tuple{T1, T2}"/> of the original file name and <see cref="FileInfo"/> object that represents the saved temporary file.
        /// </summary>
        /// <returns><see cref="IReadOnlyList{T}"/> containing a <see cref="Tuple{T1, T2}"/> of the original file name and <see cref="FileInfo"/> object that represents the saved temporary file.</returns>
        /// <exception cref="UnauthorizedAccessException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="NotSupportedException" />
        protected virtual IReadOnlyList<Tuple<string, FileInfo>> SaveRequestFilesToTemporaryLocation()
        {
            return Task.Run(() => SaveRequestFilesToTemporaryLocationAsync()).Result;
        }

        /// <summary>
        /// Saves all files contained in the <see cref="HttpContext.Request"/> to a temporary directory on the server and returns an <see cref="IReadOnlyList{T}"/> containing a <see cref="Tuple{T1, T2}"/> of the original file name and <see cref="FileInfo"/> object that represents the saved temporary file.
        /// </summary>
        /// <returns><see cref="IReadOnlyList{T}"/> containing a <see cref="Tuple{T1, T2}"/> of the original file name and <see cref="FileInfo"/> object that represents the saved temporary file.</returns>
        /// <exception cref="UnauthorizedAccessException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="PathTooLongException" />
        /// <exception cref="DirectoryNotFoundException" />
        /// <exception cref="NotSupportedException" />
        protected virtual async Task<IReadOnlyList<Tuple<string, FileInfo>>> SaveRequestFilesToTemporaryLocationAsync()
        {
            List<Tuple<string, FileInfo>> files = null;
            string fileName = null;

            if (HttpContext != null && HttpContext.Request != null && HttpContext.Request.Form != null && HttpContext.Request.Form.Files != null && HttpContext.Request.Form.Files.Any())
            {
                files = new List<Tuple<string, FileInfo>>(HttpContext.Request.Form.Files.Count);

                foreach (IFormFile file in HttpContext.Request.Form.Files)
                {
                    fileName = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(file.FileName));

                    using (FileStream fs = __File.OpenWrite(fileName))
                    {
                        await file.CopyToAsync(fs);
                        files.Add(new Tuple<string, FileInfo>(file.FileName, new FileInfo(fileName)));
                    }
                }
            }
            else
            {
                files = new List<Tuple<string, FileInfo>>();
            }

            return files.AsReadOnly();
        }

        /// <summary>
        /// Creates a new <see cref="Tuple{T1, T2}"/> containing the view name and associated view model (if any).
        /// </summary>
        /// <param name="viewName">View name to render.</param>
        /// <param name="viewModel">View model.</param>
        /// <returns><see cref="Tuple{T1, T2}"/> object.</returns>
        protected static Tuple<string, object> CreateViewViewModelTuple(string viewName, object viewModel)
        {
            return new Tuple<string, object>(viewName, viewModel);
        }

        /// <summary>
        /// Configures the root tenant object.
        /// </summary>
        private void ConfigureRootTenant()
        {
            IConfigurationSection section = null;

            if (Configuration != null && !WhippetTenant.RootTenantEstablished)
            {
                section = Configuration.GetSection(CONFIG_SECTION_TENANT);

                if (section != null)
                {
                    WhippetTenant.SetRootTenant(Guid.Parse(section[CONFIG_SECTION_TENANT__ID]), section[CONFIG_SECTION_TENANT__NAME], section[CONFIG_SECTION_TENANT__URL]);
                }
            }
        }

        /// <summary>
        /// Loads the root <see cref="IWhippetTenant"/> object from the specified configuration file.
        /// </summary>
        /// <param name="configFile">Configuration file to load.</param>
        /// <param name="sectionName">Name of the section containing the tenant information.</param>
        /// <returns><see cref="IWhippetTenant"/> object.</returns>
        /// <exception cref="FileLoadException"></exception>
        protected static IWhippetTenant LoadRootTenantFromConfiguration(string configFile = "appsettings.json", string sectionName = CONFIG_SECTION_TENANT)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(configFile)
                .Build();
            IConfigurationSection section = config.GetSection(CONFIG_SECTION_TENANT);

            WhippetTenant tenant = null;

            if (section != null)
            {
                tenant = new WhippetTenant(Guid.Parse(section[CONFIG_SECTION_TENANT__ID]), section[CONFIG_SECTION_TENANT__NAME], section[CONFIG_SECTION_TENANT__URL], null, null, null, null, true, false);
            }
            else
            {
                throw new FileLoadException(new FileLoadException().Message, configFile);
            }

            return tenant;
        }

        /// <summary>
        /// Gets the connection string with the specified name from the configuration file.
        /// </summary>
        /// <param name="configFile">Configuration file to load.</param>
        /// <param name="connectionStringName">Connection string name.</param>
        /// <returns>Connection string or <see cref="String.Empty"/> if no connection string with the given name exists.</returns>
        protected static string GetConnectionStringFromConfiguration(string configFile = "appsettings.json", string connectionStringName = "whippet")
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(configFile)
                .Build();

            return config.GetConnectionString(connectionStringName);
        }

        /// <summary>
        /// Writes raw JSON to the output response stream.
        /// </summary>
        /// <param name="rawJson">Raw JSON to emit.</param>
        /// <returns><see cref="Task"/> object.</returns>
        protected virtual async Task WriteRawJsonResponse(string rawJson)
        {
            Response.Clear();
            Response.ContentType = "application/json";
            await Response.WriteAsync(rawJson);
        }

        /// <summary>
        /// Determines if <see cref="HttpContext.Session"/> is available and configured for the specified context. 
        /// </summary>
        /// <param name="context"><see cref="HttpContext"/> object to check.</param>
        /// <returns><see langword="true"/> if the session is configured and available; otherwise, <see langword="false"/>.</returns>
        protected static bool SessionIsAvailable(HttpContext context)
        {
            bool isAvailable = false;

            if (context != null)
            {
                try
                {
                    isAvailable = (context.Session != null);
                }
                catch
                {
                    isAvailable = false;
                }
            }

            return isAvailable;
        }
    }
}
