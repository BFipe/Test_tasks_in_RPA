using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task
{
    public static class MergeFiles
    {
        public static void MergeFilesInParallel(string folderDataPath, string folderOutputFilePath, string filterString)
        {

            List<string> filePaths = Directory.GetFiles(folderDataPath, "*.txt").ToList();

            int removedRows = 0;
            using (StreamWriter outputFile = new StreamWriter(folderOutputFilePath + @"\result.txt"))
            {
                object lockObj = new object();
                Parallel.ForEach(filePaths, filePath =>
                {
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
                });
            }
            Console.WriteLine("Number of removed rows: " + removedRows);
        }
    }
}
