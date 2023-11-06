using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using NHibernate;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.NHibernate;
using Athi.Whippet.Security;

namespace Athi.Whippet.Web.Mvc
{
    /// <summary>
    /// A base class for an MVC controller with view support in Whippet and support for NHibernate. This class must be inherited.
    /// </summary>
    /// <typeparam name="TController"><see cref="Controller"/> type.</typeparam>
    public abstract class WhippetNHibernateController<TController> : WhippetController<TController>
    {
        /// <summary>
        /// Gets the default <see cref="ISessionFactory"/> object used to create NHibernate sessions. This property is read-only.
        /// </summary>
        protected virtual ISessionFactory SessionFactory
        { get; private set; }

        /// <summary>
        /// Indicates whether the supplied <see cref="ISessionFactory"/> in the constructor should be used if not <see langword="null"/>. If <see langword="null"/> or <see langword="true"/>, <see cref="SessionFactory"/> will be populated by <see cref="CreateSessionFactory"/> by a call from the constructor. This property is read-only.
        /// </summary>
        protected virtual bool UseInjectedSessionFactory
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetNHibernateController{TController}"/> class with no arguments.
        /// </summary>
        protected WhippetNHibernateController()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetNHibernateController{TController}"/> class with the specified logger and configuration accessor.
        /// </summary>
        /// <param name="logger">Logging mechanism for the current controller.</param>
        /// <param name="configuration">Configuration instance that was supplied by the caller.</param>
        /// <param name="tokenService">Token service to use.</param>
        /// <param name="sessionFactory">NHibernate session factory. If none is provided, the default bootstrapper session factory will be used.</param>
        /// <param name="externalMappings">Provides external mappings to assign to the session.</param>
        protected WhippetNHibernateController(ILogger<TController> logger, IConfiguration configuration, ITokenService tokenService, ISessionFactory sessionFactory = null, IEnumerable<NHibernateBootstrapperMappingDelegate> externalMappings = null)
            : base(logger, configuration, tokenService)
        {
            // Uncouple the bootstrapper mapping delegate as it was causing circular reference issues  --ATH 1/20/23
            //List<NHibernateBootstrapperMappingDelegate> allMappings = new List<NHibernateBootstrapperMappingDelegate>(new NHibernateBootstrapperMappingDelegate[] { WhippetNHibernateMappingIndex.ConfigureMappings });

            List<NHibernateBootstrapperMappingDelegate> allMappings = new List<NHibernateBootstrapperMappingDelegate>();

            if (externalMappings != null && externalMappings.Any())
            {
                allMappings.AddRange(externalMappings.ToList());
            }

            if (sessionFactory == null || (sessionFactory != null && !UseInjectedSessionFactory))
            {
                SessionFactory = CreateSessionFactory(allMappings);
            }
            else
            {
                SessionFactory = sessionFactory;
            }
        }

        /// <summary>
        /// Creates a new <see cref="ISession"/> object, which represents a connection to the data store.
        /// </summary>
        /// <returns><see cref="ISession"/> object.</returns>
        protected virtual ISession CreateSession()
        {
            return SessionFactory.OpenSession();
        }

        /// <summary>
        /// Creates a new <see cref="ISessionFactory"/> object used for creating NHibernate sessions. The default connection string in the configuration file is used.
        /// </summary>
        /// <param name="allMappings"><see cref="NHibernateBootstrapperMappingDelegate"/> mapping delegates to be appended to the current entity mapping index.</param>
        /// <returns><see cref="ISessionFactory"/> object.</returns>
        protected virtual ISessionFactory CreateSessionFactory(IEnumerable<NHibernateBootstrapperMappingDelegate> allMappings = null)
        {
            return NHibernateWhippetBootstrapper.CreateSessionFactory(GetConnectionString(NHibernateConstantsIndex.PrimaryConnectionStringName), allMappings);
        }
    }
}
