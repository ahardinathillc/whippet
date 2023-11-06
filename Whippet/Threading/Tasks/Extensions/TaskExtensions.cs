using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Athi.Whippet.Threading.Tasks.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="Task"/> objects. This class cannot be inherited.
    /// </summary>
    public static class TaskExtensions
    {
        /// <summary>
        /// Attempts to execute the specified <see cref="Task{T}"/> a set number of times.  
        /// </summary>
        /// <param name="func"><see cref="Func{T}"/> delegate of the function to execute.</param>
        /// <param name="retries">Number of retries to attempt execution.</param>
        /// <param name="exceptions">If provided, populates an <see cref="IList{T}"/> containing all <see cref="Exception"/> objects that were caught.</param>
        /// <typeparam name="T">Return type of function.</typeparam>
        /// <returns><see cref="Task{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static async Task<T> Try<T>(this Func<T> func, int retries, IList<Exception> exceptions = null)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            else if (retries < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(retries));
            }
            else
            {
                int i = 0;

                do
                {
                    try
                    {
                        return await Task.Run(func);
                    }
                    catch (Exception e)
                    {
                        if (exceptions != null)
                        {
                            exceptions.Add(e);
                        }
                    }

                    return await Task.Run(func);
                } while (i++ < retries);

                return default(T);
            }
        }
    }
}
