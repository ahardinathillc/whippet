using System;

namespace Athi.Whippet.Adobe.Magento
{
    /// <summary>
    /// Provides support to objects that have a corresponding <see cref="IExtensionInterface"/>.
    /// </summary>
    /// <typeparam name="TInterface"><see cref="IExtensionInterface"/> type.</typeparam>
    public interface IExtensionInterfaceMap<TInterface> where TInterface : IExtensionInterface, new() 
    {
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <typeparamref name="TInterface"/>.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <typeparamref name="TInterface"/>.</returns>
        TInterface ToInterface();

        /// <summary>
        /// Populates the current instance based on the specified <see cref="IExtensionInterface"/>.
        /// </summary>
        /// <param name="model"><typeparamref name="TInterface"/> object used to populate the object.</param>
        void FromModel(TInterface model);
    }
    
    /// <summary>
    /// Provides support to objects that have a corresponding <see cref="IExtensionInterface"/>.
    /// </summary>
    /// <typeparam name="TInterface"><see cref="IExtensionInterface"/> type.</typeparam>
    public interface IExtensionInterfaceCollectionMap<TInterface> : IExtensionInterfaceMap<TInterface> 
        where TInterface : IExtensionInterface, new() 
    {
        /// <summary>
        /// Converts the current instance to an <see cref="IExtensionInterface"/> of type <typeparamref name="TInterface"/> that is enumerable.
        /// </summary>
        /// <returns><see cref="IExtensionInterface"/> object of type <typeparamref name="TInterface"/> that is enumerable.</returns>
        new IEnumerable<TInterface> ToInterface();

        /// <summary>
        /// Populates the current instance based on the specified enumerable collection of <see cref="IExtensionInterface"/> objects.
        /// </summary>
        /// <param name="models"><typeparamref name="TInterface"/> objects used to populate the object.</param>
        void FromModel(IEnumerable<TInterface> models);
    }
}
