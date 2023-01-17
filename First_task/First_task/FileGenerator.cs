using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace First_task
{
    public static class FileGenerator
    {
        public static readonly Random random = new();

        //Parameters from Parameters.cs
        public static void GenerateFilesInParallel(int textFilesNumber, int textRowsNumber, string folderPath)
        {
            object lockObj = new object();
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            Parallel.For(0, textFilesNumber, i =>
            {
                string fileName = i + ".txt";
                using (StreamWriter sw = new StreamWriter(folderPath + @$"\{fileName}"))
                {
                    StringBuilder sb = new StringBuilder();
                    Parallel.For(0, textRowsNumber, j =>
                    {
                        lock (lockObj)
                        {
                            sb.AppendLine(GenerateRow());
                        }
                    });
                    lock (lockObj)
                    {
                        sw.Write(sb.ToString());
                    }
                }
            });
        }

        public static string GenerateRow()
        {
            string row = String.Empty;

            //Concating all generated data into a string
            row = $@"{GenerateYear()}||{GenerateLatin()}||{GenerateCyrillic()}||{GenerateInteger()}||{GenerateDouble()}||";
            return row;
        }

        private static string GenerateYear()
        {
            string generatedYear = String.Empty;        

            //Generating random year from 2018 to 2023
            int year = random.Next(DateTime.Now.Year - 5, DateTime.Now.Year + 1);

            //Generating random number of days past the year [0, 364]
            int dayOfTheYear = random.Next(0, 365);

            generatedYear = new DateTime(year, 1, 1).AddDays(dayOfTheYear).ToShortDateString().ToString();
            return generatedYear;
        }

        private static string GenerateLatin()
        {
            string generatedLatin = String.Empty;

            //Generate latin symbol by generating random number from 0 to 25 then adding to the char 'a' or 'A'
            for (int i = 0; i < 10; i++)
            {
                int branch = random.Next(0, 2);
                if (branch == 0)
                {
                    generatedLatin += (char)('a' + random.Next(0, 26));
                }
                else
                {
                    generatedLatin += (char)('A' + random.Next(0, 26));
                }
            }
            return generatedLatin;
        }

        private static string GenerateCyrillic()
        {
            string generatedLatin = String.Empty;
            
            //Generate cyrilic symbol by generating random number from 0 to 25 then adding to the char 'a' or 'A'
            for (int i = 0; i < 10; i++)
            {
                int branch = random.Next(0, 2);
                if (branch == 0)
                {
                    generatedLatin += (char)('А' + random.Next(0, 32));
                }
                else
                {
                    generatedLatin += (char)('а' + random.Next(0, 32));
                }
            }
            return generatedLatin;
        }

        private static int GenerateInteger()
        {
            int integer = 0;
            
            //Generate random number in range [1, 100_000_000]
            integer = random.Next(1, 100_000_001);
            return integer;
        }

        private static string GenerateDouble()
        {
            string doubleNumber = String.Empty;
            
            //Generate random decimal number by adding generated numbers
            doubleNumber += random.Next(1, 21).ToString() + ",";
            for (int i = 0; i < 8; i++)
            {
                doubleNumber += random.Next(1, 10);
            }

            return doubleNumber;
        }
    }
}
