using Second_Task_BusinessLayer.Interfaces;
using Second_Task_Data.Interfaces;
using Second_Task_Entities.FileEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_BusinessLayer.Services
{
    public class FileManager : IFileManager
    {
        private readonly IExcelRepository _excelRepository;
        private readonly IExcelReader _excelReader;

        public FileManager(IExcelRepository excelRepository, IExcelReader excelReader)
        {
            _excelRepository = excelRepository;
            _excelReader = excelReader;
        }

        //Saving file in wwwroot path
        public void SaveXslxInFolder(byte[] file, string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ExcelFiles", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.Write(file, 0, file.Length);
            }
        }

        //Get all data from folder and database about folder files
        public List<FolderFileEntity> GetFolderFileEntities()
        {
            List<string> dbFileNames = _excelRepository.GetExcelFileNames();

            //Getting all file's names from the ExcelFiles folder
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFiles");
            List<string> fileNames = Directory.GetFiles(folderPath).ToList();

            List<FolderFileEntity> folderFileEntities = new();
            fileNames.ForEach(file =>
            {
                //Creating folder file entity and checking if it already in the database
                var fileName = (file.Replace(folderPath + @"\", ""));

                FolderFileEntity folderFileEntity = new FolderFileEntity()
                {
                    Name = fileName,
                    IsInDatabase = dbFileNames.Contains(fileName),
                };

                folderFileEntities.Add(folderFileEntity);
            });

            return folderFileEntities;
        }

        public void DeleteFile(string fileName)
        {
            //Select file from ~/wwwroot/ExcelFiles by it's name
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFiles", fileName);

            //Checking is this file exists in that 
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new Exception($"File {fileName} not found");
            }
        }

        public async Task PushFileIntoDatabase(string fileName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFiles", fileName);
            if (File.Exists(filePath))
            {
                await _excelReader.ReadFile(filePath);
            }
            else
            {
                throw new Exception($"File {fileName} not found");
            }
        }
    }
}
