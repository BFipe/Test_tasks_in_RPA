using First_task.DatabaseOperations;
using System.Diagnostics;

namespace First_task
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var timer = new Stopwatch();
            //timer.Start();
            //FileGenerator.GenerateFilesInParallel(Parameters.TextFilesNumber, Parameters.TextRowsNumber, Parameters.FolderDataPath);
            //timer.Stop();
            //TimeSpan timeTaken = timer.Elapsed;
            //Console.WriteLine("Time taken creating files: " + timeTaken.ToString(@"m\:ss\.fff"));

            //timer.Restart();
            //MergeFiles.MergeFilesInParallel(Parameters.FolderDataPath, Parameters.FolderDataPath, "");
            //timer.Stop();
            //timeTaken = timer.Elapsed;
            //Console.WriteLine("Time taken merging: " + timeTaken.ToString(@"m\:ss\.fff"));
            //timer.Restart();
            Database db = new();
            Console.WriteLine(db.AllIntegerSum());
            Console.WriteLine(db.DoubleMedian());
            //await db.AddDataFromTxt(@"D:\Рабочий стол\Visual Studio\TesterFolder\result.txt");
            //timer.Stop();
            //timeTaken = timer.Elapsed;
            //Console.WriteLine("Time taken adding result data to database: " + timeTaken.ToString(@"m\:ss\.fff"));

        }
    }
}