using Microsoft.EntityFrameworkCore;
using Second_Task_Entities.ExcelEntities;
using Second_Task_Entities.ExcelEntities.ExcelEntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ExcelFile> ExcelFiles { get; set; }
        public DbSet<ExcelClass> ExcelClasses{ get; set; }
        public DbSet<ExcelAccountGroup> ExcelAccountGroups { get; set; }
        public DbSet<ExcelAccount> ExcelAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExcelFileConfiguration());
            modelBuilder.ApplyConfiguration(new ExcelClassConfiguration());
            modelBuilder.ApplyConfiguration(new ExcelAccountGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ExcelAccountConfiguration());
        }
    }
}
