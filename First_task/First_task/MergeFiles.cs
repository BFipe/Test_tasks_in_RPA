using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task
{
    public static class MergeFiles
    {
        public static void MergeFilesInParallel(string folderDataPath, string folderOutputFilePath, string resultFileName, string filterString)
        {

            List<string> filePaths = Directory.GetFiles(folderDataPath, "*.txt").ToList();

            int removedRows = 0;
            using (StreamWriter outputFile = new StreamWriter(folderOutputFilePath + $@"\{resultFileName}.txt"))
            {
                object lockObj = new object();
                Parallel.ForEach(filePaths, filePath =>
                {
                    Console.WriteLine($"Started merging rows from {filePath.Replace(folderDataPath + @"\", "")} to {resultFileName}.txt");

                    using (StreamReader inputFile = new StreamReader(filePath))
                    {
                        if (!String.IsNullOrEmpty(filterString))
                        {
                            while (!inputFile.EndOfStream)
                            {
                                string line = inputFile.ReadLine();
                                if (!line.Contains(filterString))
                                {
                                    lock (lockObj)
                                    {
                                        outputFile.WriteLine(line);
                                    }
                                }
                                else
                                {
                                    lock (lockObj)
                                    {
                                        removedRows++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            while (!inputFile.EndOfStream)
                            {
                                string line = inputFile.ReadLine();
                                lock (lockObj)
                                {
                                    outputFile.WriteLine(line);
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Finished merging rows from {filePath.Replace(folderDataPath + @"\", "")} to {resultFileName}.txt");

                });
            }
            Console.WriteLine("Merged sucesfully!");
            Console.WriteLine("Number of removed rows: " + removedRows);
        }
    }
}
