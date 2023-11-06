using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Athi.Whippet.Data;

namespace Athi.Whippet.Json.Newtonsoft.Serialization
{
    /// <summary>
    /// Contact resolver for serialization of <see cref="IWhippetEntity"/> objects.
    /// </summary>
    public class WhippetEntityContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetEntityContractResolver"/> class with no arguments.
        /// </summary>
        public WhippetEntityContractResolver()
            : base()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }

        /// <summary>
        /// Creates properties for the given <see cref="JsonContract"/>.
        /// </summary>
        /// <param name="type">Type that is being serialized.</param>
        /// <param name="memberSerialization">Specifies the member serialization option.</param>
        /// <returns>Properties for the given <see cref="JsonContract"/>.</returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);

            foreach (JsonProperty p in props)
            {
                p.Ignored = false;
            }

            return props;
        }
    }
}

