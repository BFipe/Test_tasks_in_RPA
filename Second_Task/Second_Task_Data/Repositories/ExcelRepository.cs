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

        public Task<List<string>> GetExcelFileNames()
        {
            return _dbContext.ExcelFiles.Select(q => q.ExcelFileName).ToListAsync();
        }

        public Task<List<ExcelFile>> GetExcelFilesInfo()
        {
            return _dbContext.ExcelFiles.ToListAsync();
        }

        public Task<ExcelFile> GetExcelFileInfo(string fileId)
        {
            return _dbContext.ExcelFiles.SingleOrDefaultAsync(q => q.ExcelFileId == fileId);
        }

        public Task<ExcelFile> GetExcelFileData(string fileId)
        {
            return _dbContext.ExcelFiles
                .Include(q => q.ExcelClasses.OrderBy(q => q.Name))
                .ThenInclude(q => q.ExcelAccountGroups.OrderBy(q => q.AccountingValue))
                .ThenInclude(q => q.ExcelAccounts.OrderBy(q => q.AccountingValue))
                .SingleOrDefaultAsync(q => q.ExcelFileId == fileId);
        }

        public Task RemoveExcelFile(ExcelFile excelFile)
        {
           _dbContext.ExcelFiles.Remove(excelFile);
            return Task.CompletedTask;
        }
    }
}
