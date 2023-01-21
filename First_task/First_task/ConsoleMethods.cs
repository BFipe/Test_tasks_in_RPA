using First_task.DatabaseOperations;
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
            //Check default parameters
            if (String.IsNullOrEmpty(Parameters.FolderDataPath))
            {
                ChangeGeneratorParameters();
                Generate();
            }
            else
            {
                //If you already have some parameters it will suggest you to use them 
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

        //Changing parameters option
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

        //main generating procedure
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
                //If you already have some parameters it will suggest you to use them 
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

        //main changing merge parameters procedure
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
                if (String.IsNullOrEmpty(anwser) && String.IsNullOrEmpty(Parameters.FolderDataPath) == false)
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
                if (String.IsNullOrEmpty(anwser) && String.IsNullOrEmpty(Parameters.FolderDataPath) == false)
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

        //main merging procedure
        private static void Merge()
        {
            MergeFiles.MergeFilesInParallel(Parameters.FolderDataPath, Parameters.FolderOutputPath, Parameters.ResultFileName, Parameters.FilterString);
        }

        //Pushing data in database procedure
        public async static Task PushData(Database database)
        {
            if (String.IsNullOrEmpty(Parameters.ResultFilePath))
            {
                ChangePushParameters();
                await PushDataIntoDB(database);
            }
            else
            {
                //If you already have some parameters it will suggest you to use them 
                Parameters.TxtFilePath = Parameters.ResultFilePath;
                Console.Clear();
                Console.WriteLine("Use this parameters? y/n");
                Console.WriteLine($".txt File path - {Parameters.TxtFilePath}");
                Console.WriteLine($"Connection string - {Parameters.ConnectionString} [Non-changable during the application]");


                string anwser = string.Empty;
                bool isTaskRunning = true;
                while (isTaskRunning)
                {
                    anwser = Console.ReadLine();
                    switch (anwser)
                    {
                        case "y":

                            await PushDataIntoDB(database);
                            isTaskRunning = false;
                            continue;
                        case "n":
                            ChangePushParameters();
                            await PushDataIntoDB(database);
                            isTaskRunning = false;
                            continue;

                        default:
                            break;
                    }
                }
            }
        }

        //changing push parameters
        private static void ChangePushParameters()
        {
            string txtFilePath = string.Empty;
            bool isTaskRunning = true;
            string anwser = String.Empty;

            Console.WriteLine("Enter the path to .txt string you want to merge or just press enter to use path for previously generated result file");
            while (isTaskRunning)
            {
                anwser = Console.ReadLine().Trim();
                if (String.IsNullOrEmpty(anwser) && String.IsNullOrEmpty(Parameters.ResultFilePath) == false)
                {
                    txtFilePath = Parameters.ResultFilePath;
                    isTaskRunning = false;
                }
                else if (Path.GetExtension(anwser) == ".txt")
                {
                    txtFilePath = anwser;
                    isTaskRunning = false;
                }
                else
                {
                    Console.WriteLine("The path is incorrect or not a .txt file.");
                }
            }

            Console.WriteLine("Check data, press any key to continue or type \"change\" to change data again");
            Console.WriteLine($".txt File path - {txtFilePath}");

            anwser = Console.ReadLine();
            if (anwser == "change")
            {
                Console.Clear();
                ChangePushParameters();
            }
            else
            {
                Parameters.TxtFilePath = txtFilePath;
            }
        }

        //Pushing data
        private async static Task PushDataIntoDB(Database database)
        {
            await database.AddDataFromTxt(Parameters.TxtFilePath);
        }

        //Get sum of all integers
        public static void GetSum(Database database)
        {
            Console.WriteLine(database.AllIntegerSum());
        }

        //get median of all decimals
        public static void GetMedian(Database database)
        {
            Console.WriteLine(database.DoubleMedian());
        }
    }
}
