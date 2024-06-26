using System;
using System.IO;
using System.Linq;


static void some(string args)
        {
            // Check if the directory path is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the directory containing the files.");
                return;
            }

            string directoryPath = args; // Assuming the directory path is passed as the first argument

            // Get all files in the directory
            try
            {
                DirectoryInfo directory = new DirectoryInfo(directoryPath);
                FileInfo[] files = directory.GetFiles();
                Console.WriteLine("Enter the keyWord you want to replace");
                var sourceName = Console.ReadLine();
                Console.WriteLine("Enter the new keyword for the file");
                
                var destionationName = Console.ReadLine();

                foreach (var file in files)
                {
                    string oldFileName = file.Name;
                    string newFileName = oldFileName.Replace(sourceName, destionationName);

                    // Rename the file
                    string newPath = Path.Combine(file.DirectoryName, newFileName);
                    File.Move(file.FullName, newPath);

                    Console.WriteLine($"Renamed file: {oldFileName} to {newFileName}");
                }

                Console.WriteLine("File renaming completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        Console.WriteLine("Enter the file location");
        some(Console.ReadLine());