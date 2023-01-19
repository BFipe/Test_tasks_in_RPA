using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_Entities.ExcelEntities
{
    public class ExcelAccount
    {
        public ExcelAccount()
        {

        }

        public ExcelAccount(int accountingValue, double activeAccountOpeningBalance, double passiveAccountOpeningBalance, double debitAccountNegotiableBalance, double creditAccountNegotiableBalance, double activeAccountOutgoingBalance, double passiveAccountOutgoingBalance)
        {
            AccountingValue = accountingValue;
            ActiveAccountOpeningBalance = activeAccountOpeningBalance;
            PassiveAccountOpeningBalance = passiveAccountOpeningBalance;
            DebitAccountNegotiableBalance = debitAccountNegotiableBalance;
            CreditAccountNegotiableBalance = creditAccountNegotiableBalance;
            ActiveAccountOutgoingBalance = activeAccountOutgoingBalance;
            PassiveAccountOutgoingBalance = passiveAccountOutgoingBalance;

            //Outgoing balance calculating algorithm
            if (ActiveAccountOpeningBalance > 0 && PassiveAccountOpeningBalance == 0)
            {
                ActualPassiveAccountOutgoingBalance = 0;

                ActualActiveAccountOutgoingBalance = Math.Round(ActiveAccountOpeningBalance + DebitAccountNegotiableBalance - CreditAccountNegotiableBalance, 2, MidpointRounding.AwayFromZero);
            }
            else if (ActiveAccountOpeningBalance == 0 && PassiveAccountOpeningBalance > 0)
            {
                ActualActiveAccountOutgoingBalance = 0;

                ActualPassiveAccountOutgoingBalance = Math.Round(PassiveAccountOpeningBalance + CreditAccountNegotiableBalance - DebitAccountNegotiableBalance, 2, MidpointRounding.AwayFromZero);
            }
            else if (ActiveAccountOpeningBalance == 0 && PassiveAccountOpeningBalance == 0)
            {
                ActualActiveAccountOutgoingBalance = 0;

                ActualPassiveAccountOutgoingBalance = 0;
            }
            else
            {
                ActualActiveAccountOutgoingBalance = Math.Round(ActiveAccountOpeningBalance - PassiveAccountOpeningBalance + DebitAccountNegotiableBalance - CreditAccountNegotiableBalance, 2, MidpointRounding.AwayFromZero);

                ActualPassiveAccountOutgoingBalance = Math.Round(PassiveAccountOpeningBalance - ActiveAccountOpeningBalance + CreditAccountNegotiableBalance - DebitAccountNegotiableBalance, 2, MidpointRounding.AwayFromZero);
            }

        }

        public string ExcelAccountId { get; set; }
        public int AccountingValue { get; set; }

        //Opening balance amount
        public double ActiveAccountOpeningBalance { get; set; }
        public double PassiveAccountOpeningBalance { get; set; }

        //Negotiable Balance amount
        public double DebitAccountNegotiableBalance { get; set; }
        public double CreditAccountNegotiableBalance { get; set; }

        //Negotiable Balance amount from excel data
        public double ActiveAccountOutgoingBalance { get; set; }
        public double PassiveAccountOutgoingBalance { get; set; }

        //Negotiable Balance amount from calculates
        public double ActualActiveAccountOutgoingBalance { get; set; }
        public double ActualPassiveAccountOutgoingBalance { get; set; }

        //One-To-Many Entity Framework parameter for ExcelAccountGroup
        public string ExcelAccountGroupId { get; set; }
        public ExcelAccountGroup ExcelAccountGroup { get; set; }
    }
}
