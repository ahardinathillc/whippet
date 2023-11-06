using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Collections.ObjectModel;
using NHibernate;
using Newtonsoft.Json.Linq;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Jobs.Repositories;

namespace Athi.Whippet.Jobs.ServiceManagers
{
    /// <summary>
    /// Service manager that reads a job configuration JSON file and loads the required assemblies into memory.
    /// </summary>
    public class JobLoaderServiceManager : ServiceManager
    {
        private const string ROOT_JOB_CATEGORY = "Available Jobs";

        private const string JSON_CATEGORIES = "Categories";
        private const string JSON_JOBS = "Jobs";
        private const string JSON_REPOSITORIES = "Repositories";
        private const string JSON_PARAMETERS = "Parameters";
        private const string JSON_MANAGERS = "Managers";
        private const string JSON_DEFAULT_LOCATION = "DefaultAssemblyDirectories";
        private const string JSON_MAPPINGS = "Mappings";
        private const string JSON_MAPPINGS_REPOSITORIES = "Repositories";
        private const string JSON_MAPPINGS_MANAGERS = "Managers";

        private List<IJobCategory> _categories;
        private List<DirectoryInfo> _assembliesDirectory;
        private List<Assembly> _assemblies;

        private Dictionary<Guid, List<IJob>> _jobs;
        private Dictionary<IJob, Type> _jobRepoMappings;
        private Dictionary<IJob, Type> _jobManagerMappings;
        private Dictionary<IJob, Type> _jobParameterMappings;
        private Dictionary<IJobParameter, Type> _parameterServiceManagerMappings;

        /// <summary>
        /// Gets an <see cref="IReadOnlyList{T}"/> that contains available <see cref="JobCategory"/> objects. This property is read-only.
        /// </summary>
        public IReadOnlyList<IJobCategory> AvailableJobCategories
        {
            get
            {
                return InternalCategories.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> containing all available <see cref="JobBase"/> objects indexed by the <see cref="IJobCategory"/> ID. This property is read-only.
        /// </summary>
        public IReadOnlyDictionary<Guid, IEnumerable<IJob>> AvailableJobs
        {
            get
            {
                Dictionary<Guid, IEnumerable<IJob>> dict = new Dictionary<Guid, IEnumerable<IJob>>();

                foreach (KeyValuePair<Guid, List<IJob>> entry in InternalJobs)
                {
                    dict.Add(entry.Key, entry.Value);
                }

                return new ReadOnlyDictionary<Guid, IEnumerable<IJob>>(dict);
            }
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyList{T}"/> of all <see cref="DirectoryInfo"/> objects of the directories where job assemblies are stored and loaded from for this instance of <see cref="JobLoaderServiceManager"/>. This property is read-only.
        /// </summary>
        public IReadOnlyList<DirectoryInfo> AssembliesDirectories
        {
            get
            {
                return InternalAssembliesDirectories.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the internal <see cref="Dictionary{TKey, TValue}"/> containing service manager mappings for <see cref="IJob"/> objects. This property is read-only.
        /// </summary>
        private Dictionary<IJob, Type> InternalServiceManagerMappings
        {
            get
            {
                if (_jobManagerMappings == null)
                {
                    _jobManagerMappings = new Dictionary<IJob, Type>();
                }

                return _jobManagerMappings;
            }
        }

        /// <summary>
        /// Gets the internal <see cref="Dictionary{TKey, TValue}"/> containing repository mappings for <see cref="IJob"/> objects. This property is read-only.
        /// </summary>
        private Dictionary<IJob, Type> InternalJobRepositoryMappings
        {
            get
            {
                if (_jobRepoMappings == null)
                {
                    _jobRepoMappings = new Dictionary<IJob, Type>();
                }

                return _jobRepoMappings;
            }
        }

        /// <summary>
        /// Gets all <see cref="Assembly"/> objects for the available objects. This property is read-only.
        /// </summary>
        private List<Assembly> InternalAssemblies
        {
            get
            {
                if (_assemblies == null)
                {
                    _assemblies = new List<Assembly>();
                }

                return _assemblies;
            }
        }

        /// <summary>
        /// Gets the internal <see cref="Dictionary{TKey, TValue}"/> that contains available <see cref="JobBase"/> objects. This property is read-only.
        /// </summary>
        private Dictionary<Guid, List<IJob>> InternalJobs
        {
            get
            {
                if (_jobs == null)
                {
                    _jobs = new Dictionary<Guid, List<IJob>>();
                }

                return _jobs;
            }
        }

        /// <summary>
        /// Gets the internal <see cref="List{T}"/> that contains available <see cref="JobCategory"/> objects. This property is read-only.
        /// </summary>
        private List<IJobCategory> InternalCategories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new List<IJobCategory>();
                }

                return _categories;
            }
        }

        /// <summary>
        /// Gets a <see cref="List{T}"/> of all <see cref="DirectoryInfo"/> objects of the directories where job assemblies are stored and loaded from for this instance of <see cref="JobLoaderServiceManager"/>. This property is read-only.
        /// </summary>
        private List<DirectoryInfo> InternalAssembliesDirectories
        {
            get
            {
                if (_assembliesDirectory == null)
                {
                    _assembliesDirectory = new List<DirectoryInfo>();
                }

                return _assembliesDirectory;
            }
        }

        /// <summary>
        /// Gets the <see cref="FileInfo"/> that contains information about the JSON file containing job configuration. This property is read-only.
        /// </summary>
        public virtual FileInfo JobFile
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobLoaderServiceManager"/> class with no arguments.
        /// </summary>
        private JobLoaderServiceManager()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobLoaderServiceManager"/> class with the specified 
        /// </summary>
        /// <param name="jobConfigurationFile">JSON file containing the assembly types of available jobs and job cateagories.</param>
        /// <param name="assembliesDirectory">Directory (or directories) in which the assemblies are stored. Use <see langword="null"/> to use default directories specified in the configuration file or to use the executing assembly's location.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public JobLoaderServiceManager(string jobConfigurationFile, params string[] assembliesDirectory)
            : this()
        {
            if (String.IsNullOrWhiteSpace(jobConfigurationFile))
            {
                throw new ArgumentNullException(nameof(jobConfigurationFile));
            }
            else
            {
                ReadSettingsFile(jobConfigurationFile, assembliesDirectory);
            }
        }

        /// <summary>
        /// Reads all available categories and job types from the specified settings file.
        /// </summary>
        /// <param name="settingsFile">JSON file containing the assembly types of available jobs and job cateagories.</param>
        /// <param name="assembliesDirectory">Directory (or directories) in which the assemblies are stored. Use <see langword="null"/> to use default directories specified in the configuration file or to use the executing assembly's location.</param>
        /// <exception cref="ArgumentNullException" />
        protected virtual void ReadSettingsFile(string settingsFile, params string[] assembliesDirectory)
        {
            if (String.IsNullOrWhiteSpace(settingsFile))
            {
                throw new ArgumentNullException(nameof(settingsFile));
            }
            else
            {
                string settings = File.ReadAllText(settingsFile);

                JObject json = JObject.Parse(settings);

                JEnumerable<JToken> categoryChildren = json[JSON_CATEGORIES].Children();
                JEnumerable<JToken> jobChildren = json[JSON_JOBS].Children();
                JEnumerable<JToken> repoChildren = json[JSON_REPOSITORIES].Children();
                JEnumerable<JToken> managerChildren = json[JSON_MANAGERS].Children();
                JEnumerable<JToken> directoryChildren = json[JSON_DEFAULT_LOCATION].Children();
                JEnumerable<JToken> mappingChildren = json[JSON_MAPPINGS].Children();

                IJEnumerable<JToken> mappingChildren_managers = JEnumerable<JToken>.Empty;
                IJEnumerable<JToken> mappingChildren_repos = JEnumerable<JToken>.Empty;

                IEnumerable<IJobCategory> categories = null;
                IEnumerable<IJob> jobs = null;
                IEnumerable<Assembly> assemblies = null;
                IEnumerable<string> paths = null;

                IReadOnlyDictionary<IJob, Type> repoMappings = null;
                IReadOnlyDictionary<IJob, Type> managerMappings = null;

                DirectoryInfo defaultDirectory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                // first we need to load the assemblies directories if they aren't already loaded

                if (assembliesDirectory == null || (assembliesDirectory != null && (assembliesDirectory.Length == 0)))
                {
                    // read from the configuration file

                    paths = ReadTokens<string>(directoryChildren, true);

                    if (paths != null && paths.Any())
                    {
                        InternalAssembliesDirectories.AddRange(paths.Select(p => new DirectoryInfo(p)));
                    }
                    else
                    {
                        InternalAssembliesDirectories.Add(defaultDirectory);
                    }
                }
                else
                {
                    InternalAssembliesDirectories.AddRange(assembliesDirectory.Select(ad => new DirectoryInfo(ad)));
                }

                categories = ReadTokens<IJobCategory>(categoryChildren);
                jobs = ReadTokens<IJob>(jobChildren);

                // read all the assemblies

                assemblies = ReadAssemblies(repoChildren);
                assemblies = assemblies.Concat(ReadAssemblies(managerChildren));

                if (assemblies != null && assemblies.Any())
                {
                    InternalAssemblies.AddRange(assemblies);
                }

                // add the available categories

                if (categories != null && categories.Any())
                {
                    InternalCategories.AddRange(categories);
                }

                // add the jobs and assign their categories

                if (jobs != null && jobs.Any())
                {
                    InternalJobs.AddRange(jobs.Select(j => j.Category.ID).Distinct());

                    foreach (Guid categoryId in InternalJobs.Keys)
                    {
                        InternalJobs[categoryId] = new List<IJob>(jobs.Where(j => j.Category.ID == categoryId));
                    }
                }

                mappingChildren_repos = json[JSON_MAPPINGS][JSON_MAPPINGS_REPOSITORIES].Values();
                mappingChildren_managers = json[JSON_MAPPINGS][JSON_MAPPINGS_MANAGERS].Values();

                repoMappings = ReadJobMappingTokens(mappingChildren_repos);
                managerMappings = ReadManagerMappingTokens(mappingChildren_managers);

                if (repoMappings != null && repoMappings.Any())
                {
                    InternalJobRepositoryMappings.ImportValues(repoMappings);
                }

                if (managerMappings != null && managerMappings.Any())
                {
                    InternalServiceManagerMappings.ImportValues(managerMappings);
                }
            }
        }

        /// <summary>
        /// Reads all service manager type mappings indexed by <see cref="IJob"/> for the specified <see cref="JToken"/> root.
        /// </summary>
        /// <param name="rootToken"><see cref="IJEnumerable{T}"/> representing the root <see cref="JToken"/> children.</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by </returns>
        private IReadOnlyDictionary<IJob, Type> ReadManagerMappingTokens(IJEnumerable<JToken> rootToken)
        {
            Dictionary<IJob, Type> mappings = new Dictionary<IJob, Type>();

            string[] pieces = null;

            bool found = false;

            if (rootToken.Any())
            {
                foreach (JToken entry in rootToken)
                {
                    if (!String.IsNullOrWhiteSpace(entry.Value<string>()))
                    {
                        pieces = entry.Value<string>().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        if (pieces != null && pieces.Length == 2)
                        {
                            foreach (KeyValuePair<Guid, IEnumerable<IJob>> jobEntry in AvailableJobs)
                            {
                                foreach (IJob availableJob in jobEntry.Value)
                                {
                                    if (String.Equals(availableJob.GetType().FullName, pieces[0], StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        // find the associated manager and load the type

                                        foreach (Assembly managerAssembly in InternalAssemblies)
                                        {
                                            foreach (Type assemblyType in managerAssembly.GetTypes())
                                            {
                                                if (String.Equals(assemblyType.FullName, pieces[1], StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    mappings.Add(availableJob, assemblyType);
                                                    found = true;
                                                    break;
                                                }
                                            }

                                            if (found)
                                            {
                                                found = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return mappings;
        }

        /// <summary>
        /// Reads all assembly type mappings indexed by <see cref="IJob"/> for the specified <see cref="JToken"/> root.
        /// </summary>
        /// <param name="rootToken"><see cref="IJEnumerable{T}"/> representing the root <see cref="JToken"/> children.</param>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by </returns>
        private IReadOnlyDictionary<IJob, Type> ReadJobMappingTokens(IJEnumerable<JToken> rootToken)
        {
            Dictionary<IJob, Type> mappings = new Dictionary<IJob, Type>();

            string[] pieces = null;

            bool found = false;

            if (rootToken.Any())
            {
                foreach (JToken entry in rootToken)
                {
                    if (!String.IsNullOrWhiteSpace(entry.Value<string>()))
                    {
                        pieces = entry.Value<string>().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                        if (pieces != null && pieces.Length == 2)
                        {
                            foreach (KeyValuePair<Guid, IEnumerable<IJob>> jobEntry in AvailableJobs)
                            {
                                foreach (IJob availableJob in jobEntry.Value)
                                {
                                    if (String.Equals(availableJob.GetType().FullName, pieces[0], StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        // find the associated assembly and load the type

                                        foreach (Assembly repoAssembly in InternalAssemblies)
                                        {
                                            foreach (Type assemblyType in repoAssembly.GetTypes())
                                            {
                                                if (String.Equals(assemblyType.FullName, pieces[1], StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    mappings.Add(availableJob, assemblyType);
                                                    found = true;
                                                    break;
                                                }
                                            }

                                            if (found)
                                            {
                                                found = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return mappings;
        }

        /// <summary>
        /// Reads <see cref="JToken"/> objects from the specified <see cref="JEnumerable{T}"/> and casts each item to an <see cref="Assembly"/> object.
        /// </summary>
        /// <param name="rootToken"><see cref="JEnumerable{T}"/> object to parse.</param>
        /// <returns><see cref="IEnumerable{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="InvalidCastException" />
        private IEnumerable<Assembly> ReadAssemblies(JEnumerable<JToken> rootToken)
        {
            List<Assembly> entries = new List<Assembly>();

            IEnumerable<JToken> values = null;

            string[] pieces = null;

            Assembly asm = null;

            if (rootToken.Any())
            {
                foreach (JToken entry in rootToken)
                {
                    values = entry.Values();

                    if (values != null && values.Any())
                    {
                        foreach (JToken token in values)
                        {
                            if (!String.IsNullOrWhiteSpace(token.Value<string>()))
                            {
                                pieces = token.Value<string>().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                                if (pieces != null && pieces.Length == 2)
                                {
                                    asm = LoadAssembly(pieces[0]);

                                    if (asm != null)
                                    {
                                        entries.Add(asm);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return entries.AsReadOnly();
        }

        /// <summary>
        /// Reads <see cref="JToken"/> objects from the specified <see cref="JEnumerable{T}"/> and casts each item to a <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/> type to cast to (class or interface).</typeparam>
        /// <param name="rootToken"><see cref="JEnumerable{T}"/> object to parse.</param>
        /// <param name="singleEntries">If <see langword="true"/>, <see cref="JToken"/> values are treated as a single entry without a delimiter.</param>
        /// <returns><see cref="IEnumerable{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FileNotFoundException" />
        /// <exception cref="InvalidCastException" />
        private IEnumerable<T> ReadTokens<T>(JEnumerable<JToken> rootToken, bool singleEntries = false)
        {
            List<T> entries = new List<T>();

            IEnumerable<JToken> values = null;

            string[] pieces = null;

            Assembly asm = null;

            T jobObj = default(T);

            if (rootToken.Any())
            {
                foreach (JToken entry in rootToken)
                {
                    values = entry.Values();

                    if (values != null && values.Any())
                    {
                        foreach (JToken token in values)
                        {
                            if (!String.IsNullOrWhiteSpace(token.Value<string>()))
                            {
                                if (!singleEntries)
                                {
                                    pieces = token.Value<string>().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                                    if (pieces != null && pieces.Length == 2)   // divided into assembly and type
                                    {
                                        asm = LoadAssembly(pieces[0]);

                                        if (asm != null)
                                        {
                                            jobObj = (T)(asm.CreateInstance(pieces[1]));

                                            if (jobObj != null)
                                            {
                                                entries.Add(jobObj);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    entries.Add(token.Value<T>());
                                }
                            }
                        }
                    }
                }
            }

            return entries.AsReadOnly();
        }

        /// <summary>
        /// Loads the specified assembly.
        /// </summary>
        /// <param name="assemblyFile">Assembly file name with optional path to the file. If no path is provided, every entry in <see cref="AssembliesDirectories"/> will be searched.</param>
        /// <returns><see cref="Assembly"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        private Assembly LoadAssembly(string assemblyFile)
        {
            if (String.IsNullOrWhiteSpace(assemblyFile))
            {
                throw new ArgumentNullException(nameof(assemblyFile));
            }
            else
            {
                Assembly asm = null;

                // check to see if the file exists in the current location

                if (!File.Exists(assemblyFile))
                {
                    // check every directory 

                    foreach (DirectoryInfo assemblyDirectory in AssembliesDirectories)
                    {
                        // load the first instance we find

                        if (File.Exists(Path.Combine(assemblyDirectory.FullName, assemblyFile)))
                        {
                            asm = Assembly.LoadFile(Path.Combine(assemblyDirectory.FullName, assemblyFile));
                            break;
                        }
                    }
                }

                if (asm == null)
                {
                    throw new FileNotFoundException(null, assemblyFile);
                }
                else
                {
                    return asm;
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="IJobServiceManager"/> for the specified <see cref="IJob"/> type.
        /// </summary>
        /// <param name="jobType"><see cref="Type"/> of the <see cref="IJob"/> to instantiate a service manager for.</param>
        /// <param name="repository"><see cref="IJobRepository"/> that encapsulates the repository which stores <see cref="IJob"/> objects of the given type.</param>
        /// <returns><see cref="IJobServiceManager"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IJobServiceManager GetJobServiceManager(Type jobType, IJobRepository repository)
        {
            if (jobType == null)
            {
                throw new ArgumentNullException(nameof(jobType));
            }
            else if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else
            {
                IJobServiceManager manager = null;
                Type managerType = null;

                IJob job = CreateJobInstance(jobType);

                if (job != null)
                {
                    managerType = InternalServiceManagerMappings[job];

                    if (managerType != null)
                    {
                        manager = (IJobServiceManager)(Activator.CreateInstance(managerType, repository));
                    }
                }

                return manager;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="IJobRepository"/> for the specified <see cref="IJob"/> type.
        /// </summary>
        /// <param name="jobType"><see cref="Type"/> of the <see cref="IJob"/> to instantiate a repository for.</param>
        /// <param name="context"><see cref="ISession"/> object representing the context of the database connection.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object that allows for bulk operations against a database.</param>
        /// <returns><see cref="IJobRepository"/> object or <see langword="null"/> if no matching repository type could be located.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IJobRepository GetJobRepository(Type jobType, ISession context, IStatelessSession statelessContext = null)
        {
            if (jobType == null)
            {
                throw new ArgumentNullException(nameof(jobType));
            }
            else if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            else
            {
                Type repoType = null;

                IJobRepository repo = null;
                IJob job = CreateJobInstance(jobType);

                if (job != null)
                {
                    repoType = InternalJobRepositoryMappings[job];

                    if (repoType != null)
                    {
                        repo = (IJobRepository)((statelessContext == null) ? Activator.CreateInstance(repoType, context) : Activator.CreateInstance(repoType, context, statelessContext));
                    }
                }

                return repo;
            }
        }

        /// <summary>
        /// Creates an instance of the specified <see cref="IJob"/> type based on available jobs that have been loaded in the current service manager.
        /// </summary>
        /// <param name="jobType"><see cref="Type"/> representing the <see cref="IJob"/> to load.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual IJob CreateJobInstance(Type jobType)
        {
            if (jobType == null)
            {
                throw new ArgumentNullException(nameof(jobType));
            }
            else
            {
                IJob job = null;
                bool found = false;

                foreach (KeyValuePair<Guid, IEnumerable<IJob>> entries in AvailableJobs)
                {
                    if (entries.Value != null && entries.Value.Any())
                    {
                        foreach (IJob j in entries.Value)
                        {
                            if (String.Equals(jobType.FullName, j.GetType().FullName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                job = j.Clone<IJob>();
                                found = true;
                                break;
                            }
                        }
                    }

                    if (found)
                    {
                        break;
                    }
                }

                return job;
            }
        }
    }
}
