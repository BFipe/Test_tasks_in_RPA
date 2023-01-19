using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Entities.ExcelEntities
{
    public class ExcelClass
    {
        public string ExcelClassId { get; set; }
        public string Name { get; set; }

        //Opening balance total amount
        public double TotalActiveClassOpeningBalance { get; set; }
        public double TotalPassiveClassOpeningBalance { get; set; }

        //Negotiable Balance total amount
        public double TotalDebitClassNegotiableBalance { get; set; }
        public double TotalCreditClassNegotiableBalance { get; set; }

        //Negotiable Balance total amount from excel data
        public double TotalActiveClassOutgoingBalance { get; set; }
        public double TotalPassiveClassOutgoingBalance { get; set; }

        //Negotiable Balance total amount from calculated data
        public double ActualTotalActiveClassOutgoingBalance { get; set; }
        public double ActualTotalPassiveClassOutgoingBalance { get; set; }

        //One-To-Many Entity Framework parameter for ExcelAccountGroup
        public List<ExcelAccountGroup> ExcelAccountGroups { get; set; } = new();

        //One-To-Many Entity Framework parameter for ExcelFile
        public string ExcelFileId { get; set; }
        public ExcelFile ExcelFile { get; set; }

        //Start and end position for class values, clarified during first document analysys
        public int StartingValuesRow { get; set; }
        public int EndingValuesRow { get; set; }
    }
}
