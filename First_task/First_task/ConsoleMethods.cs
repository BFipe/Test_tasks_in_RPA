using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace First_task
{
    public static class ConsoleMethods
    {
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public static void GenerateFiles()
        {
            if (String.IsNullOrEmpty(Parameters.FolderDataPath))
            {
                ChangeGeneratorParameters();
                Generate();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Use this parameters? y/n");
                Console.WriteLine($"Number of files - {Parameters.TextFilesNumber}");
                Console.WriteLine($"Number of rows in 1 file - {Parameters.TextRowsNumber}");
                Console.WriteLine($"Folder output path - {Parameters.FolderDataPath}");

                string anwser = string.Empty;
                bool isTaskRunning = true;
                while (isTaskRunning)
                {
                    anwser = Console.ReadLine();
                    switch (anwser)
                    {
                        case "y":
                            Generate();
                            isTaskRunning = false;
                            continue;
                        case "n":
                            ChangeGeneratorParameters();
                            Generate();
                            isTaskRunning = false;
                            continue;

                        default:
                            break;
                    }
                }
            }
        }


        private static void ChangeGeneratorParameters()
        {
            int numOfFiles = 0;
            int numOfRows = 0;
            string path = string.Empty;
            string anwser = string.Empty;
            bool isTaskRunning = true;

            Console.WriteLine("Enter the number of files");
            while (isTaskRunning)
            {
                anwser = Console.ReadLine();
                isTaskRunning = !int.TryParse(anwser, out numOfFiles);
            }

            isTaskRunning = true;

            Console.WriteLine("Enter the number of rows in file");
            while (isTaskRunning)
            {
                anwser = Console.ReadLine();
                isTaskRunning = !int.TryParse(anwser, out numOfRows);
            }

            isTaskRunning = true;

            Console.WriteLine("Enter the path to output folder");
            while (isTaskRunning)
            {
                anwser = Console.ReadLine();
                if (!Regex.IsMatch(anwser, Parameters.InvalidPathPattern) || Directory.Exists(anwser))
                {
                    path = anwser;
                    isTaskRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid path entered. Please, check if your path is valid and enter again.");
                }
            }

            Console.WriteLine("Check data, press any key to continue or type \"change\" to change data again");
            Console.WriteLine($"Number of files - {numOfFiles}");
            Console.WriteLine($"Number of rows in 1 file - {numOfRows}");
            Console.WriteLine($"Folder output path - {path}");
            anwser = Console.ReadLine();
            if (anwser == "change")
            {
                Console.Clear();
                ChangeGeneratorParameters();
            }
            else
            {
                Parameters.TextFilesNumber = numOfFiles;
                Parameters.TextRowsNumber = numOfRows;
                Parameters.FolderDataPath = path;
            }

        }

        private static void Generate()
        {
            Console.Clear();
            FileGenerator.GenerateFilesInParallel(Parameters.TextFilesNumber, Parameters.TextRowsNumber, Parameters.FolderDataPath);
        }

        public static void MergeFilesProcedure()
        {
            if (String.IsNullOrEmpty(Parameters.FolderDataPath) || String.IsNullOrEmpty(Parameters.FolderOutputPath) || String.IsNullOrEmpty(Parameters.ResultFileName))
            {
                ChangeMergeParameters();
                Merge();
            }
            else
            {
                Console.WriteLine("Use this parameters? y/n");
                Console.WriteLine($"Folder with merging data - {Parameters.FolderDataPath}");
                Console.WriteLine($"Folder output path - {Parameters.FolderOutputPath}");
                Console.WriteLine($"Result file name - {Parameters.ResultFileName}");
                Console.WriteLine($"Filter string - {Parameters.FilterString}");

                string anwser = string.Empty;
                bool isTaskRunning = true;
                while (isTaskRunning)
                {
                    anwser = Console.ReadLine();
                    switch (anwser)
                    {
                        case "y":
                            Merge();
                            isTaskRunning = false;
                            continue;

                        case "n":
                            ChangeMergeParameters();
                            Merge();
                            isTaskRunning = false;
                            continue;

                        default:
                            break;
                    }
                }
            }
        }

        private static void ChangeMergeParameters()
        {
            string outputPath = string.Empty;
            string inputPath = string.Empty;
            string resultName = string.Empty;
            string filterString = string.Empty;
            string anwser = string.Empty;
            bool isTaskRunning = true;

            Console.WriteLine("Enter the path with generated data (or just press enter to use previous path with generated files)");
            while (isTaskRunning)
            {
                anwser = Console.ReadLine();
                if (String.IsNullOrEmpty(anwser))
                {
                    inputPath = Parameters.FolderDataPath;
                    isTaskRunning = false;
                }
                else if (Directory.Exists(anwser))
                {
                    inputPath = anwser;
                    isTaskRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid path entered. Please, check if your path is valid and enter again.");
                }
            }

            isTaskRunning = true;

            Console.WriteLine("Enter the path to output folder (or just press enter to use previous path with generated files)");
            while (isTaskRunning)
            {
                anwser = Console.ReadLine();
                if (String.IsNullOrEmpty(anwser))
                {
                    outputPath = Parameters.FolderDataPath;
                    isTaskRunning = false;
                }
                else if (Directory.Exists(anwser))
                {
                    outputPath = anwser;
                    isTaskRunning = false;
                }
                else
                {
                    Console.WriteLine("Invalid path entered. Please, check if your path is valid and enter again.");
                }
            }

            isTaskRunning = true;

            Console.WriteLine("Enter result file name");
            while (isTaskRunning)
            {
                anwser = Console.ReadLine();
                if (String.IsNullOrEmpty(anwser) || Regex.IsMatch(anwser, Parameters.InvalidNamePattern))
                {
                    Console.WriteLine("Invalid name. Please, check if your data and enter again.");
                }
                else
                {
                    resultName = anwser;
                    isTaskRunning = false;
                }
            }

            Console.WriteLine("Enter filter string or just press enter to disable it");
            filterString = Console.ReadLine();

            Console.WriteLine("Check data, press any key to continue or type \"change\" to change data again");
            Console.WriteLine($"Folder with merging data - {inputPath}");
            Console.WriteLine($"Folder output path - {outputPath}");
            Console.WriteLine($"Result file name - {resultName}");
            Console.WriteLine($"Filter string - {filterString}");
            anwser = Console.ReadLine();
            if (anwser == "change")
            {
                Console.Clear();
                ChangeMergeParameters();
            }
            else
            {
                Parameters.FolderDataPath = inputPath;
                Parameters.FolderOutputPath = outputPath;
                Parameters.ResultFileName = resultName;
                Parameters.FilterString = filterString;
            }
        }

        private static void Merge()
        {
            MergeFiles.MergeFilesInParallel(Parameters.FolderDataPath, Parameters.FolderOutputPath, Parameters.ResultFileName, Parameters.FilterString);
        }
    }
}
