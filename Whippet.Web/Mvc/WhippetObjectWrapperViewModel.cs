using System;

namespace Athi.Whippet.Web.Mvc
{
    /// <summary>
    /// Provides a wrapper for view models that wrap around a domain object. This class must be inherited.
    /// </summary>
    /// <typeparam name="TObject">Type of object that is being wrapped by the view model.</typeparam>
    public abstract class WhippetObjectWrapperViewModel<TObject>
        where TObject : new()
    {
        private TObject _obj;

        /// <summary>
        /// If <see langword="true"/> and <typeparamref name="TObject"/> is a reference type, <see cref="InternalObject"/> will default to <see langword="null"/> if no initial value is set. Otherwise, the default constructor will be called.
        /// </summary>
        protected virtual bool DefaultToNull
        { get; private set; }

        /// <summary>
        /// Gets the instance of the <typeparamref name="TObject"/> object that is being wrapped. This property is read-only.
        /// </summary>
        protected virtual TObject InternalObject
        {
            get
            {
                if (_obj == null && !DefaultToNull)
                {
                    _obj = new TObject();
                }

                return _obj;
            }
            private set
            {
                _obj = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetObjectWrapperViewModel{TObject}"/> class with no arguments.
        /// </summary>
        internal WhippetObjectWrapperViewModel()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetObjectWrapperViewModel{TObject}"/> class with the specified <typeparamref name="TObject"/> object.
        /// </summary>
        /// <param name="obj"><typeparamref name="TObject"/> object to initialize with.</param>
        /// <param name="defaultToNull">If <see langword="true"/> and <typeparamref name="TObject"/> is a reference type, <see cref="InternalObject"/> will default to <see langword="null"/> if no initial value is set. Otherwise, the default constructor will be called.</param>
        protected WhippetObjectWrapperViewModel(TObject obj, bool defaultToNull = false)
            : this()
        {
            InternalObject = obj;
            DefaultToNull = defaultToNull;
        }
    }

    /// <summary>
    /// Provides a wrapper for view models that wrap around a domain object. This class must be inherited.
    /// </summary>
    /// <typeparam name="TInterface">Interface (or parent type) that <typeparamref name="TObject"/> implements.</typeparam>
    /// <typeparam name="TObject">Type of object that is being wrapped by the view model.</typeparam>
    public abstract class WhippetObjectWrapperViewModel<TInterface, TObject> : WhippetObjectWrapperViewModel<TObject>
        where TObject : TInterface, new()
    {
        /// <summary>
        /// Gets the instance of the <typeparamref name="TInterface"/> object that is being wrapped. This property is read-only.
        /// </summary>
        protected virtual new TInterface InternalObject
        {
            get
            {
                return base.InternalObject;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetObjectWrapperViewModel{TInterface, TObject}"/> class with no arguments.
        /// </summary>
        private WhippetObjectWrapperViewModel()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetObjectWrapperViewModel{TObject}"/> class with the specified <typeparamref name="TInterface"/> object.
        /// </summary>
        /// <param name="obj"><typeparamref name="TInterface"/> object to initialize with.</param>
        /// <param name="defaultToNull">If <see langword="true"/> and <typeparamref name="TInterface"/> is a reference type, <see cref="InternalObject"/> will default to <see langword="null"/> if no initial value is set. Otherwise, the default constructor will be called.</param>
        protected WhippetObjectWrapperViewModel(TInterface obj, bool defaultToNull = false)
            : base((TObject)(obj), defaultToNull)
        { }
    }
}

