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

        public FileManager(IExcelRepository excelRepository)
        {
            _excelRepository = excelRepository;
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
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFiles");
            List<string> fileNames = Directory.GetFiles(folderPath).ToList();

            List<FolderFileEntity> folderFileEntities = new();
            fileNames.ForEach(file =>
            {
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
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ExcelFiles", fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
                throw new Exception($"File {fileName} not found");
            }
        }
    }
}
