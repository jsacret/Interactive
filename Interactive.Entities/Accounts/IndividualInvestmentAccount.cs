using Interactive.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interactive.Model.Bank;

namespace Interactive.Model.Accounts
{
    public class IndividualInvestmentAccount : InvestmentAccount
    {
        public IndividualInvestmentAccount(decimal initialBalance, Customer owner) : base(initialBalance, owner)
        {
        }

        public override void Debit(decimal amount)
        {
            if(amount > 1000)
            {
                throw new DebitException("Amount exceeds debit limit of this account type.");
            }

            base.Debit(amount);
        }
    }
}
