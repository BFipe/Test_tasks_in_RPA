using Second_Task_BusinessLayer.Dtos;
using Second_Task_Entities.ExcelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_BusinessLayer.Interfaces
{
    public interface IExcelManager
    {
        public Task ReadFile(string xlsxFilePath);

        public List<DbFileInfo> GetFilesInfo();
        public Task<ExcelFile> GetFileData();
        public Task DeleteFile(string fileId);
    }
}
