using System.Diagnostics;

namespace First_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();
            FileGenerator.GenerateFilesInParallel(Parameters.TextFilesNumber, Parameters.TextRowsNumber, Parameters.FolderDataPath);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine("Time taken creating files: " + timeTaken.ToString(@"m\:ss\.fff"));

            timer.Restart();
            MergeFiles.MergeFilesInParallel(Parameters.FolderDataPath, Parameters.FolderDataPath, "b");
            timer.Stop();
            timeTaken = timer.Elapsed;
            Console.WriteLine("Time taken merging: " + timeTaken.ToString(@"m\:ss\.fff"));
        }
    }
}