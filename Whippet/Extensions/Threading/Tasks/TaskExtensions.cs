using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Athi.Whippet.Extensions.Threading.Tasks
{
    /// <summary>
    /// Provides extension methods to <see cref="Task"/> objects. This class cannot be inherited.
    /// </summary>
    public static class TaskExtensions
    {
        private static readonly TaskFactory _taskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        /// <summary>
        /// Executes an asynchronous task method which has a void return value synchronously.
        /// </summary>
        /// <param name="obj">Object to invoke the method on.</param>
        /// <param name="task">Task method to execute.</param>
        /// <exception cref="ArgumentNullException" />
        public static void RunSync(this object obj, Func<Task> task)
            => _taskFactory
                .StartNew(task)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        /// <summary>
        /// Executes an asynchronous task method synchronously.
        /// </summary>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <param name="obj">Object to invoke the method on.</param>
        /// <param name="task">Task method to execute.</param>
        /// <exception cref="ArgumentNullException" />
        public static TResult RunSync<TResult>(this object obj, Func<Task<TResult>> task)
            => _taskFactory
                .StartNew(task)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}
