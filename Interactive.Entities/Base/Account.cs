using Interactive.Model.Bank;
using Interactive.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive.Model.Base
{
    public abstract class Account
    {
        public Account(decimal initialBalance, Customer owner)
        {
            _balance = initialBalance;
            Owner = owner;
        }
        public Customer Owner { get; }
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            protected set
            {
                if (value < 0)
                {
                    throw new DebitException("Insufficient Funds");
                }
                _balance = value; }
        }

        public virtual void Debit(decimal amount)
        { 
            Balance -= amount;
        }
        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public virtual void TransferTo(Account account, decimal amount)
        {
            this.Debit(amount);
            account.Deposit(amount);
        }

    }
}
