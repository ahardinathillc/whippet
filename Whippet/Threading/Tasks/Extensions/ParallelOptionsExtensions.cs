using System;
using System.Threading.Tasks;
using _Environment = System.Environment;

namespace Athi.Whippet.Threading.Tasks.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ParallelOptions"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ParallelOptionsExtensions
    {
        private const int MAC_OS_SONOMA_INITIAL_VERSION_MAJOR = 14;
        private const int MAC_OS_SONOMA_INITIAL_VERSION_MINOR = 0;

        /// <summary>
        /// Determines the optimal processor count based on the running environment's operating system and processor count.
        /// </summary>
        /// <param name="pOptions"><see cref="ParallelOptions"/> object.</param>
        /// <param name="useHalfOfProcessorCount">If <see langword="true"/>, will only use half of the available processors in the system.</param>
        /// <returns><see cref="ParallelOptions"/> object.</returns>
        public static ParallelOptions DetermineOptimalCoreCount(this ParallelOptions pOptions, bool useHalfOfProcessorCount = false)
        {
            int processorCount = _Environment.ProcessorCount;

            if (pOptions == null)
            {
                pOptions = new ParallelOptions();
            }

            if (OperatingSystem.IsMacOS() || useHalfOfProcessorCount)
            {
                if (OperatingSystem.IsMacOSVersionAtLeast(MAC_OS_SONOMA_INITIAL_VERSION_MAJOR, MAC_OS_SONOMA_INITIAL_VERSION_MINOR) || useHalfOfProcessorCount)
                {
                    if (OperatingSystem.IsMacOSVersionAtLeast(MAC_OS_SONOMA_INITIAL_VERSION_MAJOR, MAC_OS_SONOMA_INITIAL_VERSION_MINOR + 1))
                    {
                        pOptions.MaxDegreeOfParallelism = -1;
                    }
                    else
                    {
                        if (useHalfOfProcessorCount || (OperatingSystem.IsMacOSVersionAtLeast(MAC_OS_SONOMA_INITIAL_VERSION_MAJOR, MAC_OS_SONOMA_INITIAL_VERSION_MINOR) && !OperatingSystem.IsMacOSVersionAtLeast(MAC_OS_SONOMA_INITIAL_VERSION_MAJOR, MAC_OS_SONOMA_INITIAL_VERSION_MINOR + 1)))
                        {
                            if ((_Environment.ProcessorCount % 2) != 0)
                            {
                                if (_Environment.ProcessorCount == 1)
                                {
                                    processorCount = 2;
                                }
                                else
                                {
                                    processorCount = (_Environment.ProcessorCount - 1);
                                }
                            }

                            pOptions.MaxDegreeOfParallelism = Convert.ToInt32(processorCount / 2);
                        }
                        else
                        {
                            pOptions.MaxDegreeOfParallelism = -1;
                        }
                    }
                }
                else
                {
                    pOptions.MaxDegreeOfParallelism = -1;
                }
            }

            return pOptions;
        }
    }
}
