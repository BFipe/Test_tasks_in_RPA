using Second_Task_Entities.ExcelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Data.Interfaces
{
    public interface IExcelRepository
    {
        public Task AddExcelFile(ExcelFile excelFile);

        public Task<ExcelFile> GetExcelFileInfo(string fileId);
        public Task<ExcelFile> GetExcelFileData(string fileId);

        public Task<List<ExcelFile>> GetExcelFilesInfo();
        public Task<List<string>> GetExcelFileNames();
        public Task RemoveExcelFile(ExcelFile excelFile);
        public Task SaveDatabase();
    }
}
