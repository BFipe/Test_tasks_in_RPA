using First_task.DatabaseOperations.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task.DatabaseOperations
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(string connectionString)
        {
            Parameters.ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //String-connection to MSSQL Database
            optionsBuilder.UseSqlServer(Parameters.ConnectionString);
        }

        //Our table with data
        public DbSet<TableEntity> TableEntities { get; set; }

        //Applying TableEntityConfiguration to DbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TableEntityConfiguration());
        }
    }
}
