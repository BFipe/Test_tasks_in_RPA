using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Entities.ExcelEntities
{
    public class ExcelAccountGroup
    {
        public string ExcelAccountGroupId { get; set; }
        public int AccountingValue { get; set; }

        //Opening balance total amount
        public double TotalActiveAccountOpeningBalance { get; set; }
        public double TotalPassiveAccountOpeningBalance { get; set; }

        //Negotiable Balance total amount
        public double TotalDebitAccountNegotiableBalance { get; set; }
        public double TotalCreditAccountNegotiableBalance { get; set; }

        //Negotiable Balance total amount from excel data
        public double TotalActiveAccountOutgoingBalance { get; set; }
        public double TotalPassiveAccountOutgoingBalance { get; set; }

        //Negotiable Balance total amount from calculates
        public double ActualTotalActiveAccountOutgoingBalance { get; set; }
        public double ActualTotalPassiveAccountOutgoingBalance { get; set; }

        //One-To-Many Entity Framework parameter for ExcelClass
        public string ExcelClassId { get; set; }
        public ExcelClass ExcelClass { get; set; }

        //One-To-Many Entity Framework parameter for ExcelAccount
        public List<ExcelAccount> ExcelAccounts { get; set; } = new();

        //Start and end position for account values, clarified during first document analysys
        public int StartingValuesRow { get; set; }
        public int EndingValuesRow { get; set; }
    }
}
