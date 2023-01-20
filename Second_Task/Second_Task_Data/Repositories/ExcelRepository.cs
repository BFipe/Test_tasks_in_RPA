using Microsoft.EntityFrameworkCore;
using Second_Task_Data.Interfaces;
using Second_Task_Entities.ExcelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Data.Repositories
{
    public class ExcelRepository : IExcelRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExcelRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task AddExcelFile(ExcelFile excelFile)
        {
            await _dbContext.AddAsync(excelFile);
        }

        public async Task SaveDatabase()
        {
            await _dbContext.SaveChangesAsync();
        }

        public List<string> GetExcelFileNames()
        {
            return _dbContext.ExcelFiles.Select(q => q.ExcelFileName).ToList();
        }

        public List<ExcelFile> GetExcelFilesInfo()
        {
            return _dbContext.ExcelFiles.ToList();
        }

        public Task<ExcelFile> GetExcelFile(string fileId)
        {
            return _dbContext.ExcelFiles.SingleOrDefaultAsync(q => q.ExcelFileId == fileId);
        }

        public void RemoveExcelFile(ExcelFile excelFile)
        {
            _dbContext.ExcelFiles.Remove(excelFile);
        }
    }
}
