using OfficeOpenXml;
using Second_Task_BusinessLayer.Dtos;
using Second_Task_BusinessLayer.Interfaces;
using Second_Task_Data.Interfaces;
using Second_Task_Entities.ExcelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Second_Task_BusinessLayer.Services
{
    public class ExcelManager : IExcelManager
    {
        private const string ClassNamePattern = @"^(?i)класс\s+\d+.*";
        private const string AccountGroupNamePattern = @"^\d{2}$";
        private readonly IExcelRepository _excelRepository;

        public ExcelManager(IExcelRepository excelRepository)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _excelRepository = excelRepository;
        }

        public async Task<List<DbFileInfo>> GetFilesInfo()
        {
            var info = await _excelRepository.GetExcelFilesInfo();
            List<DbFileInfo> dbFileInfos = new();
            info.ForEach(data =>
            {
                DbFileInfo dbFileInfo = new DbFileInfo()
                {
                    ExcelFileId = data.ExcelFileId,
                    ExcelFileName = data.ExcelFileName
                };
                dbFileInfos.Add(dbFileInfo);
            });
            return dbFileInfos;
        }

        public async Task ReadFile(string xlsxFilePath)
        {
            if (File.Exists(xlsxFilePath) == false ||Path.GetExtension(xlsxFilePath) != ".xlsx") throw new Exception($"Path {xlsxFilePath} isn't correct or not a .xlsx file");

            using (var reader = new ExcelPackage(new FileInfo(xlsxFilePath)))
            {
                //creating new class object ExcelFile
                var worksheet = reader.Workbook.Worksheets[0];
                ExcelFile excelFile = new ExcelFile()
                {
                    ExcelFileId = Guid.NewGuid().ToString(),
                    ExcelFileName = Path.GetFileName(xlsxFilePath),
                    ExcelFileDescription = worksheet.Cells[2, 1].Text + " " + worksheet.Cells[3, 1].Text + " " + worksheet.Cells[4, 1].Text,
                    ExcelFileBankName = worksheet.Cells[1, 1].Text,
                };

                //Checking all excel list
                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {

                        var cellValue = worksheet.Cells[row, col].Text.Trim();


                        //detecting every КЛАСС row 
                        if (Regex.IsMatch(cellValue, ClassNamePattern))
                        {
                            ExcelClass excelClass = new ExcelClass()
                            {
                                ExcelClassId = Guid.NewGuid().ToString(),
                                Name = cellValue,
                                StartingValuesRow = row + 1,
                            };

                            if (excelFile.ExcelClasses.Any())
                            {
                                excelFile.ExcelClasses.Last().EndingValuesRow = row - 1;
                            }

                            excelFile.ExcelClasses.Add(excelClass);
                        }
                        if (cellValue == "БАЛАНС")
                        {
                            excelFile.ExcelClasses.Last().EndingValuesRow = row - 1;
                        }
                    }
                }

                //Validating file
                ValidateFile(excelFile.ExcelClasses, worksheet);

                excelFile.ExcelClasses.ForEach(excelClass =>
                {
                    for (int row = excelClass.StartingValuesRow; row <= excelClass.EndingValuesRow; row++)
                    {
                        var cellValue = worksheet.Cells[row, 1].Text.Trim();
                        if (Regex.IsMatch(cellValue, AccountGroupNamePattern))
                        {
                            ExcelAccountGroup excelAccountGroup = new ExcelAccountGroup()
                            {
                                ExcelAccountGroupId = Guid.NewGuid().ToString(),
                                AccountingValue = int.Parse(cellValue),
                                EndingValuesRow = row - 1,
                            };

                            if (excelClass.ExcelAccountGroups.Any() == false)
                            {
                                excelAccountGroup.StartingValuesRow = excelClass.StartingValuesRow;
                            }
                            else
                            {
                                excelAccountGroup.StartingValuesRow = excelClass.ExcelAccountGroups.Last().EndingValuesRow + 2;
                            }

                            excelClass.ExcelAccountGroups.Add(excelAccountGroup);
                        }
                    }

                    excelClass.ExcelAccountGroups.ForEach(excelAccountGroup =>
                    {
                        for (int row = excelAccountGroup.StartingValuesRow; row <= excelAccountGroup.EndingValuesRow; row++)
                        {
                            try
                            {
                                int accountingValue = int.Parse(worksheet.Cells[row, 1].Text);
                                double activeAccountOpeningBalance = double.Parse(worksheet.Cells[row, 2].Text);
                                double passiveAccountOpeningBalance = double.Parse(worksheet.Cells[row, 3].Text);
                                double debitAccountNegotiableBalance = double.Parse(worksheet.Cells[row, 4].Text);
                                double creditAccountNegotiableBalance = double.Parse(worksheet.Cells[row, 5].Text);
                                double debitAccountOutgoingBalance = double.Parse(worksheet.Cells[row, 6].Text);
                                double creditAccountOutgoingBalance = double.Parse(worksheet.Cells[row, 7].Text);
                                ExcelAccount excelAccount = new ExcelAccount(accountingValue, activeAccountOpeningBalance, passiveAccountOpeningBalance, debitAccountNegotiableBalance, creditAccountNegotiableBalance, debitAccountOutgoingBalance, creditAccountOutgoingBalance)
                                {
                                    ExcelAccountId = Guid.NewGuid().ToString(),
                                };
                                excelAccountGroup.ExcelAccounts.Add(excelAccount);
                            }
                            catch (Exception)
                            {
                                throw new Exception($"There is some issues trying to parce data from the file (Row:{row})");
                            }
                        }

                        //Calculating sum of all ExcelAccounts
                        excelAccountGroup.TotalActiveAccountOpeningBalance = Math.Round(excelAccountGroup.ExcelAccounts.Sum(q => q.ActiveAccountOpeningBalance), 2, MidpointRounding.AwayFromZero);
                        excelAccountGroup.TotalPassiveAccountOpeningBalance = Math.Round(excelAccountGroup.ExcelAccounts.Sum(q => q.PassiveAccountOpeningBalance), 2, MidpointRounding.AwayFromZero);
                        excelAccountGroup.TotalDebitAccountNegotiableBalance = Math.Round(excelAccountGroup.ExcelAccounts.Sum(q => q.DebitAccountNegotiableBalance), 2, MidpointRounding.AwayFromZero);
                        excelAccountGroup.TotalCreditAccountNegotiableBalance = Math.Round(excelAccountGroup.ExcelAccounts.Sum(q => q.CreditAccountNegotiableBalance), 2, MidpointRounding.AwayFromZero);
                        excelAccountGroup.TotalActiveAccountOutgoingBalance = Math.Round(excelAccountGroup.ExcelAccounts.Sum(q => q.ActiveAccountOutgoingBalance), 2, MidpointRounding.AwayFromZero);
                        excelAccountGroup.TotalPassiveAccountOutgoingBalance = Math.Round(excelAccountGroup.ExcelAccounts.Sum(q => q.PassiveAccountOutgoingBalance), 2, MidpointRounding.AwayFromZero);

                        //Calculating sum for calculated fields
                        excelAccountGroup.ActualTotalActiveAccountOutgoingBalance = Math.Round(excelAccountGroup.ExcelAccounts.Sum(q => q.ActualActiveAccountOutgoingBalance), 2, MidpointRounding.AwayFromZero);
                        excelAccountGroup.ActualTotalPassiveAccountOutgoingBalance = Math.Round(excelAccountGroup.ExcelAccounts.Sum(q => q.ActualPassiveAccountOutgoingBalance), 2, MidpointRounding.AwayFromZero);
                    });

                    //Calculating sum of all ExcelAccountsGroups
                    excelClass.TotalActiveClassOpeningBalance = Math.Round(excelClass.ExcelAccountGroups.Sum(q => q.TotalActiveAccountOpeningBalance), 2, MidpointRounding.AwayFromZero);
                    excelClass.TotalPassiveClassOpeningBalance = Math.Round(excelClass.ExcelAccountGroups.Sum(q => q.TotalPassiveAccountOpeningBalance), 2, MidpointRounding.AwayFromZero);
                    excelClass.TotalDebitClassNegotiableBalance = Math.Round(excelClass.ExcelAccountGroups.Sum(q => q.TotalDebitAccountNegotiableBalance), 2, MidpointRounding.AwayFromZero);
                    excelClass.TotalCreditClassNegotiableBalance = Math.Round(excelClass.ExcelAccountGroups.Sum(q => q.TotalCreditAccountNegotiableBalance), 2, MidpointRounding.AwayFromZero);
                    excelClass.TotalActiveClassOutgoingBalance = Math.Round(excelClass.ExcelAccountGroups.Sum(q => q.TotalActiveAccountOutgoingBalance), 2, MidpointRounding.AwayFromZero);
                    excelClass.TotalPassiveClassOutgoingBalance = Math.Round(excelClass.ExcelAccountGroups.Sum(q => q.TotalPassiveAccountOutgoingBalance), 2, MidpointRounding.AwayFromZero);

                    //Calculating sum for calculated fields
                    excelClass.ActualTotalActiveClassOutgoingBalance = Math.Round(excelClass.ExcelAccountGroups.Sum(q => q.ActualTotalActiveAccountOutgoingBalance), 2, MidpointRounding.AwayFromZero);
                    excelClass.ActualTotalPassiveClassOutgoingBalance = Math.Round(excelClass.ExcelAccountGroups.Sum(q => q.ActualTotalPassiveAccountOutgoingBalance), 2, MidpointRounding.AwayFromZero);
                });

                //Calculating sum of all ExcelFile
                excelFile.TotalActiveOpeningBalance = Math.Round(excelFile.ExcelClasses.Sum(q => q.TotalActiveClassOpeningBalance), 2, MidpointRounding.AwayFromZero);
                excelFile.TotalPassiveOpeningBalance = Math.Round(excelFile.ExcelClasses.Sum(q => q.TotalPassiveClassOpeningBalance), 2, MidpointRounding.AwayFromZero);
                excelFile.TotalDebitNegotiableBalance = Math.Round(excelFile.ExcelClasses.Sum(q => q.TotalDebitClassNegotiableBalance), 2, MidpointRounding.AwayFromZero);
                excelFile.TotalCreditNegotiableBalance = Math.Round(excelFile.ExcelClasses.Sum(q => q.TotalCreditClassNegotiableBalance), 2, MidpointRounding.AwayFromZero);
                excelFile.TotalActiveOutgoingBalance = Math.Round(excelFile.ExcelClasses.Sum(q => q.TotalActiveClassOutgoingBalance), 2, MidpointRounding.AwayFromZero);
                excelFile.TotalPassiveOutgoingBalance = Math.Round(excelFile.ExcelClasses.Sum(q => q.TotalPassiveClassOutgoingBalance), 2, MidpointRounding.AwayFromZero);

                //Calculating sum for calculated fields
                excelFile.ActualTotalActiveOutgoingBalance = Math.Round(excelFile.ExcelClasses.Sum(q => q.ActualTotalActiveClassOutgoingBalance), 2, MidpointRounding.AwayFromZero);
                excelFile.ActualTotalPassiveOutgoingBalance = Math.Round(excelFile.ExcelClasses.Sum(q => q.ActualTotalPassiveClassOutgoingBalance), 2, MidpointRounding.AwayFromZero);

                await _excelRepository.AddExcelFile(excelFile);

                await _excelRepository.SaveDatabase();
            };
        }

        //This method validates .xlsx
        private void ValidateFile(List<ExcelClass> excelClasses, ExcelWorksheet worksheet)
        {
            if (excelClasses.Any() == false) throw new Exception("File does not contains valid data for this application");
            try
            {
                //Trying to parse data from the first row
                var excelClass = excelClasses.First();
                double.Parse(worksheet.Cells[excelClass.StartingValuesRow, 2].Text);
                double.Parse(worksheet.Cells[excelClass.StartingValuesRow, 3].Text);
                double.Parse(worksheet.Cells[excelClass.StartingValuesRow, 4].Text);
                double.Parse(worksheet.Cells[excelClass.StartingValuesRow, 5].Text);
                double.Parse(worksheet.Cells[excelClass.StartingValuesRow, 6].Text);
                double.Parse(worksheet.Cells[excelClass.StartingValuesRow, 7].Text);
            }
            catch (Exception)
            {
                throw new Exception("File does not contains valid data for this application");
            }
        }

        public async Task DeleteFile(string fileId)
        {
            var file = await _excelRepository.GetExcelFileInfo(fileId);
            if (file == null) throw new Exception($"Database does not contains file with id {fileId}");

            await _excelRepository.RemoveExcelFile(file);
            await _excelRepository.SaveDatabase();
        }

        public async Task<ExcelFile> GetFileData(string fileId)
        {
            return await _excelRepository.GetExcelFileData(fileId);  
        }
    }
}

