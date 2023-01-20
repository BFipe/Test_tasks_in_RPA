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
        public Task<ExcelFile> GetExcelFile(string fileId);
        public List<ExcelFile> GetExcelFilesInfo();
        public List<string> GetExcelFileNames();
        public void RemoveExcelFile(ExcelFile excelFile);
        public Task SaveDatabase();
    }
}
