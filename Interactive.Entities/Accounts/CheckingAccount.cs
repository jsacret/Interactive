using Interactive.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interactive.Model.Bank;

namespace Interactive.Model.Accounts
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(decimal initialBalance, Customer owner) : base(initialBalance, owner)
        {
        }
    }
}
