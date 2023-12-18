using System;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Data
{
    /// <summary>
    /// Represents an individual database table key (primary or foreign) within a Multichannel Order Manager database.  
    /// </summary>
    public interface IMultichannelOrderManagerEntityKey : IEqualityComparer<IMultichannelOrderManagerEntityKey>, IConvertible
    {
        /// <summary>
        /// Gets the <see cref="Type"/> of the underlying value. This property is read-only.
        /// </summary>
        Type ValueType
        { get; }
        
        /// <summary>
        /// Returns the inner value of the current <see cref="IMultichannelOrderManagerEntityKey"/> object.
        /// </summary>
        /// <typeparam name="T">Type of value stored in the <see cref="IMultichannelOrderManagerEntityKey"/>. Values who are of a different type will attempt to be converted.</typeparam>
        /// <returns>Inner value.</returns>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        T ToValue<T>() where T : struct;
    }
}
