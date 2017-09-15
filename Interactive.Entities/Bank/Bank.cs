using Interactive.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive.Model.Bank
{
    public class Bank
    {
        public string BankName { get; set; }
        private IEnumerable<Account> BankAccounts { get; set; }

    }
}
