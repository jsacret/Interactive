﻿using Interactive.Model.Base;
using Interactive.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interactive.Model.Bank;

namespace Interactive.Model.Accounts
{
    public class InvestmentAccount : Account
    {
        public InvestmentAccount(decimal initialBalance, Customer owner) : base(initialBalance, owner)
        {
        }
    }
}
