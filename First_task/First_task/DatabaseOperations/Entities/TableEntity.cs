using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task.DatabaseOperations.Entities
{
    public class TableEntity
    {
        public int TableEntityId { get; set; }

        //Our parameters
        public DateTime Date { get; set; }
        public string LatinSymbols { get; set; }
        public string CyrillicSymbols { get; set; }
        public int IntegerNumber { get; set; }
        public double DoubleNumber { get; set; }
    }
}
