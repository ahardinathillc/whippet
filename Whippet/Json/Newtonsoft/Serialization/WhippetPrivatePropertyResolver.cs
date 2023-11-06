using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Athi.Whippet.Json.Newtonsoft.Serialization
{
    /// <summary>
    /// Provides a property resolver for properties that are read-only. This class cannot be inherited.
    /// </summary>
    /// <remarks>See <a href="https://talkdotnet.wordpress.com/2019/03/15/newtonsoft-json-deserializing-objects-that-have-private-setters/">Newtonsoft Json – Deserializing objects that have private setters</a> by Ryan Gunn for more information.</remarks>
    public sealed class WhippetPrivatePropertyResolver : DefaultContractResolver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetPrivatePropertyResolver"/> class with no arguments.
        /// </summary>
        public WhippetPrivatePropertyResolver()
            : base()
        { }

        /// <summary>
        /// Creates a <see cref="JsonProperty"/> for the given <see cref="MemberInfo"/>.
        /// </summary>
        /// <param name="member">The member to create a <see cref="JsonProperty"/> for.</param>
        /// <param name="memberSerialization">The member's parent <see cref="MemberSerialization"/>.</param>
        /// <returns>A created <see cref="JsonProperty"/> for the given <see cref="MemberInfo"/>.</returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            PropertyInfo propertyInfo = null;

            if (property != null)
            {
                if (!property.Writable)
                {
                    propertyInfo = member as PropertyInfo;

                    if (propertyInfo != null)
                    {
                        property.Writable = propertyInfo.GetSetMethod(true) != null;
                    }
                }
            }

            return property;
        }
    }
}
