using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Simple File Management System!");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Create a file");
                Console.WriteLine("2. Create a directory");
                Console.WriteLine("3. Write to a file");
                Console.WriteLine("4. Delete a file");
                Console.WriteLine("5. Delete a directory");
                Console.WriteLine("6. Display files in a directory");
                Console.WriteLine("7. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateFile();
                        break;
                    case "2":
                        CreateDirectory();
                        break;
                    case "3":
                        WriteToFile();
                        break;
                    case "4":
                        DeleteFile();
                        break;
                    case "5":
                        DeleteDirectory();
                        break;
                    case "6":
                        DisplayFiles();
                        break;
                    case "7":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateFile()
        {
            Console.Write("Enter the file path to create: ");
            string filePath = Console.ReadLine();

            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    Console.WriteLine($"File created at {filePath}");
                }
                else
                {
                    Console.WriteLine("File already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
            }
        }

        static void CreateDirectory()
        {
            Console.Write("Enter the directory path to create: ");
            string directoryPath = Console.ReadLine();

            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine($"Directory created at {directoryPath}");
                }
                else
                {
                    Console.WriteLine("Directory already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating directory: {ex.Message}");
            }
        }

        static void WriteToFile()
        {
            Console.Write("Enter the file path to write to: ");
            string filePath = Console.ReadLine();

            try
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine("Enter the text you want to write to the file:");
                    string content = Console.ReadLine();

                    File.AppendAllText(filePath, content + Environment.NewLine);
                    Console.WriteLine("Text written to the file successfully.");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        static void DeleteFile()
        {
            Console.Write("Enter the file path to delete: ");
            string filePath = Console.ReadLine();

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"File deleted at {filePath}");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }

        static void DeleteDirectory()
        {
            Console.Write("Enter the directory path to delete: ");
            string directoryPath = Console.ReadLine();

            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                    Console.WriteLine($"Directory deleted at {directoryPath}");
                }
                else
                {
                    Console.WriteLine("Directory does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting directory: {ex.Message}");
            }
        }

        static void DisplayFiles()
        {
            Console.Write("Enter the directory path to display files: ");
            string directoryPath = Console.ReadLine();

            try
            {
                if (Directory.Exists(directoryPath))
                {
                    string[] files = Directory.GetFiles(directoryPath);
                    Console.WriteLine($"Files in {directoryPath}:");
                    foreach (string file in files)
                    {
                        Console.WriteLine(file);
                    }
                }
                else
                {
                    Console.WriteLine("Directory does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error displaying files: {ex.Message}");
            }
        }
    }
}
