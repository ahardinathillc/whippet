using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Athi.Whippet.Reflection.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="MethodInfo"/> objects. This class cannot be inherited.
    /// </summary>
    /// <remarks>See <a href="https://stackoverflow.com/questions/39674988/how-to-call-a-generic-async-method-using-reflection">How to call a generic async method using reflection</a> from StackOverflow for more information.</remarks>
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// Invokes the specified awaitable asynchronous method dynamically.
        /// </summary>
        /// <typeparam name="T">Type of object to return.</typeparam>
        /// <param name="methodInfo"><see cref="MethodInfo"/> object that points to the invocation point.</param>
        /// <param name="obj">Object to invoke the method upon.</param>
        /// <param name="parameters">Parameters to pass to the method.</param>
        /// <returns><see cref="Task{TResult}"/> object.</returns>
        /// <exception cref="TargetException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="TargetParameterCountException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="NotSupportedException" />
        public static async Task<T> InvokeAsync<T>(this MethodInfo methodInfo, object obj, params object[] parameters)
        {
            dynamic awaitable = methodInfo.Invoke(obj, parameters);
            await awaitable;
            return (T)awaitable.GetAwaiter().GetResult();
        }

        /// <summary>
        /// Invokes the specified awaitable asynchronous method dynamically.
        /// </summary>
        /// <param name="methodInfo"><see cref="MethodInfo"/> object that points to the invocation point.</param>
        /// <param name="obj">Object to invoke the method upon.</param>
        /// <param name="parameters">Parameters to pass to the method.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="TargetException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="TargetInvocationException" />
        /// <exception cref="TargetParameterCountException" />
        /// <exception cref="MethodAccessException" />
        /// <exception cref="InvalidOperationException" />
        /// <exception cref="NotSupportedException" />
        public static async Task InvokeAsync(this MethodInfo methodInfo, object obj, params object[] parameters)
        {
            dynamic awaitable = methodInfo.Invoke(obj, parameters);
            await awaitable;
        }
    }
}

