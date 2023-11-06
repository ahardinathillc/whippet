using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Athi.Whippet.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="Type"/> objects. This class cannot be inherited.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns an assembly-qualified name while removing the comma from the full name.
        /// </summary>
        /// <param name="type"><see cref="Type"/> value.</param>
        /// <returns>Assembly-qualified name.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string ToFormattedString(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            else
            {
                string[] typeArray = type.AssemblyQualifiedName.Split(" ".ToCharArray());
                return typeArray[0] + " " + typeArray[1].Replace(",", "");
            }
        }

        /// <summary>
        /// Indicates whether the specified <see cref="Type"/> is a primitive numeric type.
        /// </summary>
        /// <param name="type"><see cref="Type"/> to check.</param>
        /// <returns><see langword="true"/> if <paramref name="type"/> is a primitive numeric type; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsNumericType(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            else
            {
                Type[] numericTypes = new[]
                {
                    typeof(byte),
                    typeof(sbyte),
                    typeof(ushort),
                    typeof(short),
                    typeof(uint),
                    typeof(int),
                    typeof(ulong),
                    typeof(long),
                    typeof(float),
                    typeof(double),
                    typeof(decimal)
                };

                return numericTypes.Contains(type);
            }
        }

        /// <summary>
        /// Gets all public and non-public properties for a specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type"><see cref="Type"/> instance to get properties for.</param>
        /// <param name="flags"><see cref="BindingFlags"/> used to filter what properties to return.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="PropertyInfo"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public static IEnumerable<PropertyInfo> GetNonPublicProperties(this Type type, BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            else
            {
                return type.GetProperties(flags).Where(c => (c.GetMethod != null && (c.GetMethod.IsPublic || c.GetMethod.IsFamily)) || (c.SetMethod != null && (c.SetMethod.IsPublic || c.SetMethod.IsFamily)));
            }
        }

        /// <summary>
        /// Gets the default value assigned to an instance upon instantiation with no assignment.
        /// </summary>
        /// <param name="type"><see cref="Type"/> to get the default instance for.</param>
        /// <returns>Default instance of specified <see cref="Type"/>.</returns>
        /// <remarks>See <a href="https://stackoverflow.com/questions/7068043/how-to-get-the-default-value-for-a-valuetype-type-with-reflection">How to get the default value for a ValueType Type with reflection</a> for more information.</remarks>
        public static object GetDefault(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var valueProperty = type.GetProperty("Value");
                type = valueProperty.PropertyType;
            }

            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
