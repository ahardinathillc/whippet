using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Athi.Whippet.Reflection
{
    /// <summary>
    /// Provides a type catalog of loaded assemblies.
    /// </summary>
    public class AssemblyTypeCatalog : ITypeCatalog
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects that are currently loaded. This property is read-only.
        /// </summary>
        public IEnumerable<Type> LoadedTypes
        { get; private set; }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> of all <see cref="Assembly"/> objects that failed to resolve. This property is read-only.
        /// </summary>
        public IReadOnlyDictionary<Assembly, Exception> FailedAssemblies
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyTypeCatalog"/> class with no arguments.
        /// </summary>
        private AssemblyTypeCatalog()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyTypeCatalog"/> class with the specified collection of <see cref="Assembly"/> objects.
        /// </summary>
        /// <param name="assemblies"><see cref="IEnumerable{T}"/> collection of <see cref="Assembly"/> objects.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AssemblyTypeCatalog(IEnumerable<Assembly> assemblies)
            : this()
        {
            if(assemblies == null)
            {
                throw new ArgumentNullException(nameof(assemblies));
            }
            else
            {
                List<Type> types = new List<Type>();
                Dictionary<Assembly, Exception> failed = new Dictionary<Assembly, Exception>();

                foreach(Assembly asm in assemblies)
                {
                    try
                    {
                        types.AddRange(asm.GetTypes());
                    }
                    catch(Exception e)
                    {
                        failed.Add(asm, e);
                    }
                }

                LoadedTypes = types.AsReadOnly();
                FailedAssemblies = failed;
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all derived <see cref="Type"/> objects from the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type"><see cref="Type"/> object to infer derived <see cref="Type"/> objects from.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public IEnumerable<Type> GetDerivedTypes(Type type)
        {
            if(type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            else
            {
                return (
                           from derivedType in LoadedTypes
                           where !type.Equals(derivedType)
                           where type.IsAssignableFrom(derivedType)
                           select derivedType);
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all derived <see cref="Type"/> objects from the specified <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">Object type to infer derived <see cref="Type"/> objects from.</typeparam>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        public IEnumerable<Type> GetDerivedTypes<T>()
        {
            return GetDerivedTypes(typeof(T));
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all generic interfaces from the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type"><see cref="Type"/> object to list all generic interface <see cref="Type"/> objects from.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public IEnumerable<Type> GetGenericInterfaceImplementations(Type type)
        {
            if(type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            else
            {
                return (from derivedType in LoadedTypes
                        from interfaceType in derivedType.GetInterfaces()
                        where interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == type
                        select derivedType).Distinct();
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all generic interfaces from the specified <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T">Object type to get all generic interface implementations for.</typeparam>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public IEnumerable<Type> GetGenericInterfaceImplementations<T>()
        {
            return GetGenericInterfaceImplementations(typeof(T));
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all interfaces from the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type"><see cref="Type"/> object to list all interface <see cref="Type"/> objects from.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public IEnumerable<Type> GetInterfaceImplementations(Type type)
        {
            return (from derivedType in LoadedTypes
                    where !derivedType.IsInterface
                    from interfaceType in derivedType.GetInterfaces()
                    where interfaceType.Equals(type)
                    select derivedType).Distinct();
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> collection of all interfaces from the specified <typeparamref name="T"/> object.
        /// </summary>
        /// <typeparam name="T">Object type to get all interface implementations for.</typeparam>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="Type"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public IEnumerable<Type> GetInterfaceImplementations<T>()
        {
            return GetInterfaceImplementations(typeof(T));
        }

    }
}
