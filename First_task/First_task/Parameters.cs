using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task
{
    public static class Parameters
    {
        //Set default file parameters from the task
        public static int TextFilesNumber = 100;
        public static int TextRowsNumber = 100_000;
        public static string FolderDataPath = String.Empty;
        public static string FolderOutputPath = String.Empty;
        public static string ResultFileName = String.Empty;
        public static string FilterString = String.Empty;

        public static string ResultFilePath = String.Empty;
        public static string TxtFilePath = String.Empty;

        public static string ConnectionString = @"Server=localhost;Database=Task1;Trusted_Connection=True;";

        public const string InvalidNamePattern = @"[\\/:*?""<>|]";
        public const string InvalidPathPattern = @"[/*?""<>|]";

    }
}
