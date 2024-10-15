using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        // Define the root directory where you want to search for folders
        string rootDirectory = @"D:\Office\games\games"; // The main directory
        string zipFileName = "g.zip"; // The name of the zip file

        // Get all directories in the root directory
        var directories = Directory.GetDirectories(rootDirectory);

        foreach (var dir in directories)
        {
            // Construct the path to the .src folder within each subdirectory
            string srcDirectory = Path.Combine(dir, ".src");
            string zipFilePath = Path.Combine(srcDirectory, zipFileName);

            if (File.Exists(zipFilePath))
            {
                Console.WriteLine($"Found zip file: {zipFilePath}");

                // Define the extraction path
                string extractPath = srcDirectory;

                try
                {
                    // Unzip the file
                    ZipFile.ExtractToDirectory(zipFilePath, extractPath, overwriteFiles: true);
                    Console.WriteLine($"Extracted: {zipFilePath} to {extractPath}");

                    // Delete the zip file after extraction
                    File.Delete(zipFilePath);
                    Console.WriteLine($"Deleted zip file: {zipFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file {zipFilePath}: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"No zip file found in {srcDirectory}");
            }
        }

        Console.WriteLine("Processing complete.");
    }
}
