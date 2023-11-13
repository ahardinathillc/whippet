using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Athi.Whippet.Tools
{
    /// <summary>
    /// Represents the Whippet Project Importer instance. This class cannot be inherited.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point for the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(params string[] args)
        {
            Tuple<string, string> pattern = null;
            
            string directory = null;
            string line = null;
            
            string[] patterns = null;

            bool success = true;

            List<FileInfo> files = null;

            StreamReader reader = null;

            StringBuilder readerContents = null;

            Regex regex = null;
            
            Console.WriteLine("**********************************************");
            Console.WriteLine("* Whippet Project Importer                   *");
            Console.WriteLine("*                                            *");
            Console.WriteLine("* Renames namespaces and assemblies for use  *");
            Console.WriteLine("* in a 3rd-party project.                    *");
            Console.WriteLine("*                                            *");
            Console.WriteLine(String.Format("* Copyright (c) {0} Athi, LLC.               *", DateTime.Now.Year));
            Console.WriteLine("*                                            *");
            Console.WriteLine("**********************************************");
            Console.WriteLine();
            Console.WriteLine("Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Console.WriteLine();
            
            if (args == null || args.Length < 2)
            {
                pattern = PromptForRename();
            }
            else
            {
                pattern = new Tuple<string, string>(args[0], args[1]);
            }

            if (args.Length >= 3)   // third argument is target directory
            {
                directory = args[2];
            }
            else
            {
                directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            }

            if (args.Length >= 4)   // fourth argument is a comma-delimited string of patterns to match
            {
                patterns = args[3].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                patterns = new string[] { "*.*" };
            }

            files = new List<FileInfo>(Int32.MaxValue / 2);
            
            DirectorySearch(directory, patterns, files);

            if (files != null && files.Any())
            {
                regex = new Regex(pattern.Item1);
                
                foreach (FileInfo file in files)
                {
                    success = true;
                    
                    try
                    {
                        Console.WriteLine("Processing " + file.ToString() + "...");

                        readerContents = new StringBuilder();

                        reader = file.OpenText();

                        do
                        {
                            line = reader.ReadLine();

                            if (!String.IsNullOrWhiteSpace(line))
                            {
                                line = regex.Replace(line, pattern.Item2, 1);
                            }

                            readerContents.AppendLine(line);
                        } while (!reader.EndOfStream);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Skipping file " + file.ToString() + ": " + e.Message);
                        success = false;
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                            reader.Dispose();
                        }
                    }

                    if (success)
                    {
                        try
                        {
                            File.WriteAllText(file.FullName, readerContents.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Couldn't write file " + file.ToString() + ": " + e.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves all files within the specified directory. Recursively calls into each subdirectory thereafter.
        /// </summary>
        /// <param name="baseDirectory">Base directory to begin searching.</param>
        /// <param name="searchPattern">File search pattern.</param>
        /// <exception cref="ArgumentNullException"></exception>
        private static void DirectorySearch(string baseDirectory, string[] searchPattern, List<FileInfo> files)
        {
            if (String.IsNullOrWhiteSpace(baseDirectory))
            {
                throw new ArgumentNullException(nameof(baseDirectory));
            }
            else if (files == null)
            {
                throw new ArgumentNullException(nameof(files));
            }
            else
            {
                string[] fileNames = null;

                if (!SkipDirectory(baseDirectory))
                {
                    if (searchPattern == null || searchPattern.Length == 0)
                    {
                        searchPattern = new string[] { "*.*" };
                    }

                    try
                    {
                        Console.WriteLine("Reading files from " + baseDirectory + "...");

                        foreach (string pattern in searchPattern)
                        {
                            fileNames = Directory.GetFiles(baseDirectory, pattern);

                            if (fileNames != null && fileNames.Length > 0)
                            {
                                files.AddRange(fileNames.Select(f => new FileInfo(f)).Where(f => !String.Equals(f.Extension, ".dll", StringComparison.InvariantCultureIgnoreCase)
                                                                                                 && !String.Equals(f.Extension, ".pdb", StringComparison.InvariantCultureIgnoreCase)
                                                                                                 && !String.Equals(f.Extension, ".exe", StringComparison.InvariantCultureIgnoreCase)
                                                                                                 && !IsBinaryFile(f)));
                            }
                        }

                        foreach (string directory in Directory.GetDirectories(baseDirectory))
                        {
                            DirectorySearch(directory, searchPattern, files);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Could not read file or directory: " + e.Message);
                    }
                }
            }
        }
        
        /// <summary>
        /// Prompts the user to enter the original value to search for and the new value to replace it with.
        /// </summary>
        /// <returns><see cref="Tuple{T1,T2}"/> value.</returns>
        private static Tuple<string, string> PromptForRename()
        {
            string oldValue = null;
            string newValue = null;
            
            Console.WriteLine("Please enter the original value to change (or press enter to use 'Athi'):");
            oldValue = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(oldValue))
            {
                oldValue = "Athi";
            }
            
            Console.WriteLine("Please enter the new value (or press enter to use 'Athi'):");
            newValue = Console.ReadLine();
            
            if (String.IsNullOrWhiteSpace((newValue)))
            {
                newValue = "Athi";
            }

            return new Tuple<string, string>(oldValue, newValue);
        }

        /// <summary>
        /// Looks for a given number of required consecutive NUL characters in a file to determine if it's a text file.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="requiredConsecutiveNul"></param>
        /// <returns></returns>
        /// <remarks>See <a href="https://stackoverflow.com/questions/4744890/c-sharp-check-if-file-is-text-based">C# - Check if File is Text Based</a> for more information.</remarks>
        private static bool IsBinaryFile(FileInfo file, int requiredConsecutiveNul = 1)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            else
            {
                const int charsToCheck = 8000;
                const char nulChar = '\0';

                int nulCount = 0;

                using (StreamReader streamReader = new StreamReader(file.FullName))
                {
                    for (var i = 0; i < charsToCheck; i++)
                    {
                        if (streamReader.EndOfStream)
                            return false;

                        if ((char) streamReader.Read() == nulChar)
                        {
                            nulCount++;

                            if (nulCount >= requiredConsecutiveNul)
                                return true;
                        }
                        else
                        {
                            nulCount = 0;
                        }
                    }
                }

                return false;                
            }
        }

        /// <summary>
        /// Determines if the specified directory needs to be skipped.
        /// </summary>
        /// <param name="directory">Directory name.</param>
        /// <returns><see langword="true"/> if the directory needs to be skipped; otherwise, <see langword="false"/>.</returns>
        private static bool SkipDirectory(string directory)
        {
            return !String.IsNullOrWhiteSpace(directory)
                   && (directory.EndsWith("/obj", StringComparison.InvariantCultureIgnoreCase)
                   || directory.EndsWith("\\obj", StringComparison.InvariantCultureIgnoreCase)
                   || directory.EndsWith("/bin", StringComparison.InvariantCultureIgnoreCase)
                   || directory.EndsWith("\\bin", StringComparison.InvariantCultureIgnoreCase)
                   || directory.EndsWith("/.git", StringComparison.InvariantCultureIgnoreCase)
                   || directory.EndsWith("\\.git", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}