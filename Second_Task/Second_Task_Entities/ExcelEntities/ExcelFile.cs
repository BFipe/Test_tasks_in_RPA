using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Entities.ExcelEntities
{
    public class ExcelFile
    {
        public string ExcelFileId { get; set; }
        public string ExcelFileName { get; set; }
        public string ExcelFileDescription { get; set; }
        public string ExcelFileBankName { get; set; }

        //Opening balance total amount
        public double TotalActiveOpeningBalance { get; set; }
        public double TotalPassiveOpeningBalance { get; set; }

        //Negotiable Balance total amount
        public double TotalDebitNegotiableBalance { get; set; }
        public double TotalCreditNegotiableBalance { get; set; }

        //Negotiable Balance total amount from excel data
        public double TotalActiveOutgoingBalance { get; set; }
        public double TotalPassiveOutgoingBalance { get; set; }

        //Negotiable Balance total amount from calculated data
        public double ActualTotalActiveOutgoingBalance { get; set; }
        public double ActualTotalPassiveOutgoingBalance { get; set; }

        //One-To-Many Entity Framework parameter for ExcelClass
        public List<ExcelClass> ExcelClasses { get; set; } = new();
    }
}
