using First_task.DatabaseOperations.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task.DatabaseOperations
{
    public class Database
    {
        private readonly TaskDbContext _dbContext;

        public Database(string connectionString)
        {
            _dbContext = new TaskDbContext(connectionString);
        }

        public async Task AddDataFromTxt(string txtFilePath)
        {
            if (Path.GetExtension(txtFilePath) != ".txt")
            {
                Console.WriteLine("The path is not a .txt file.");
                return;
            }

            int rowsAddedCounter = 0;
            Console.WriteLine("Counting the total number of rows...");
            int rowsTotalCounter = File.ReadAllLines(txtFilePath).Length;
            Console.WriteLine($"The total number of rows is {rowsTotalCounter}");

            int dataPackCount = rowsTotalCounter / 200;
            Console.WriteLine("_______________________________________________________");
            Console.WriteLine("Beginning of the process:");

            using (StreamReader reader = new StreamReader(txtFilePath))
            {
                List<TableEntity> tableEntities = new List<TableEntity>();
                while (!reader.EndOfStream)
                {
                    string data = await reader.ReadLineAsync();
                    string[] values = data.Split("||");

                    TableEntity entity = new()
                    {
                        Date = DateTime.Parse(values[0]),
                        LatinSymbols = values[1],
                        CyrillicSymbols = values[2],
                        IntegerNumber = int.Parse(values[3]),
                        DecimalNumber = decimal.Parse(values[4])
                    };

                    tableEntities.Add(entity);
                    rowsAddedCounter++;

                    if (tableEntities.Count == dataPackCount)
                    {
                        await _dbContext.TableEntities.AddRangeAsync(tableEntities);
                        await _dbContext.SaveChangesAsync();
                        Console.WriteLine($"{String.Format("{0:0.0}", ((double)rowsAddedCounter / rowsTotalCounter * 100))}% done ({rowsAddedCounter} of {rowsTotalCounter} rows)");
                        tableEntities.Clear();
                    }
                }
                if (tableEntities.Any())
                {
                    await _dbContext.TableEntities.AddRangeAsync(tableEntities);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine($"100% done ({rowsAddedCounter} of {rowsTotalCounter} rows)");
                    tableEntities.Clear();
                }
                Console.WriteLine($"Sucsesfully imported {rowsAddedCounter} rows out of {rowsTotalCounter} in the database!");
            }
        }
        public double AllIntegerSum()
        {
            return _dbContext.TableEntities.Sum(q => (double)q.IntegerNumber);
        }

        public decimal DoubleMedian()
        {
            var decimalNumbers = _dbContext.TableEntities.Select(q => q.DecimalNumber).OrderBy(q => q).ToList();
            if (decimalNumbers.Count % 2 == 1)
            {
                return decimalNumbers[(decimalNumbers.Count / 2 + 1)];
            }
            else
            {
                return (decimalNumbers[(decimalNumbers.Count / 2)] + decimalNumbers[(decimalNumbers.Count / 2 - 1)]) / 2;
            }
        }
    }
}

