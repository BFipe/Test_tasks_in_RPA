using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task.DatabaseOperations
{
    public class Database
    {
        private readonly TaskDbContext _dbContext;

        public Database()
        {
            _dbContext = new TaskDbContext();
        }
    }
}
