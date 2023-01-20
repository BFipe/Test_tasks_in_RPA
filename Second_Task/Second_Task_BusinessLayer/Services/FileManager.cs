using Second_Task_BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_BusinessLayer.Services
{
    public class FileManager : IFileManager
    {
        public void SaveXslxInFolder(byte[] file, string fileName)
        {
            if (file != null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ExcelFiles", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    fileStream.Write(file, 0, file.Length);
                }
            }
            else
            {
                throw new Exception("No file was selected");
            }
        }
    }
}
