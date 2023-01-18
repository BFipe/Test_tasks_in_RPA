using First_task.DatabaseOperations;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace First_task
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            bool isExit = true;
            string anwser = string.Empty;

            while (isExit)
            {
                Console.WriteLine("Select the operation (enter 1-5 to select operation or type \"exit\" to exit)");
                Console.WriteLine("1. Generate files");
                Console.WriteLine("2. Merge files");
                Console.WriteLine("3. Send data to the database");
                Console.WriteLine("4. Find summ of all integers");
                Console.WriteLine("5. Find median of all decimals");
                Console.WriteLine("-----------------------------------------------------------------");
                anwser = Console.ReadLine();
                switch (anwser)
                {
                    case "1":
                        ConsoleMethods.GenerateFiles();
                        ConsoleMethods.PressAnyKey();
                        break;

                    case "2":
                        ConsoleMethods.MergeFilesProcedure();
                        ConsoleMethods.PressAnyKey();
                        break;

                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
                        break;

                    case "exit":
                        return;

                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }
}