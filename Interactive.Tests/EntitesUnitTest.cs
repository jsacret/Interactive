using Interactive.Model.Accounts;
using Interactive.Model.Bank;
using Interactive.Model.Base;
using Interactive.Model.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive.Tests
{
    [TestClass]
    public class AccountUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(DebitException))]
        public void DebitMoreThanThousandIndividualTest()
        {
            Customer owner = new Customer();
            owner.CustomerName = "John Smith";
            owner.CustomerAccountId = 1231;

            IndividualInvestmentAccount individualAccount = new IndividualInvestmentAccount(2000, owner);
            individualAccount.Debit(10000);
        }

        [TestMethod]
        public void DebitTest()
        {
            Customer owner = new Customer();
            owner.CustomerName = "John Smith";
            owner.CustomerAccountId = 1231;

            IndividualInvestmentAccount individualAccount = new IndividualInvestmentAccount(10000, owner);
            individualAccount.Debit(1000);
            Assert.AreEqual(9000, individualAccount.Balance);

            CorporateInvestmentAccount CorpAccount = new CorporateInvestmentAccount(10000, owner);
            CorpAccount.Debit(5545.55M);
            Assert.AreEqual(4454.45M, CorpAccount.Balance);

            CheckingAccount checkingAccount = new CheckingAccount(2500, owner);
            checkingAccount.Debit(1200);
            Assert.AreEqual(1300, checkingAccount.Balance);

        }

        [TestMethod]
        public void DepositTest()
        {
            Customer owner = new Customer();
            owner.CustomerName = "John Smith";
            owner.CustomerAccountId = 1231;

            IndividualInvestmentAccount individualAccount = new IndividualInvestmentAccount(9000, owner);
            individualAccount.Deposit(1000);
            Assert.AreEqual(10000, individualAccount.Balance);

            CorporateInvestmentAccount CorpAccount = new CorporateInvestmentAccount(4454.45M, owner);
            CorpAccount.Deposit(5545.55M);
            Assert.AreEqual(10000, CorpAccount.Balance);

            CheckingAccount checkingAccount = new CheckingAccount(1300, owner);
            checkingAccount.Deposit(1200);
            Assert.AreEqual(2500, checkingAccount.Balance);
        }

        [TestMethod]
        public void ConfirmTransferTest()
        {
            CheckingAccount johnsAccount = new CheckingAccount(10000, new Customer() { CustomerAccountId = 1231, CustomerName = "John Smith" });
            CheckingAccount salliesAccount = new CheckingAccount(10000, new Customer() { CustomerAccountId = 1233, CustomerName = "Sallie Smith" });

            Assert.AreEqual(10000, johnsAccount.Balance);
            Assert.AreEqual(10000, salliesAccount.Balance);

            johnsAccount.TransferTo(salliesAccount, 50.55M);

            Assert.AreEqual(9949.45M, johnsAccount.Balance);
            Assert.AreEqual(10050.55M, salliesAccount.Balance);
        }

        [TestMethod]
        public void ConfirmAccountAlwaysHasOwnerPropertyTest()
        {
            var type = typeof(Account);
            var property = type.GetProperty("Owner");

            Assert.IsNotNull(property);
        }

        [TestMethod]
        public void ConfirmAllAccountsAreAccountBase()
        {
            //Checking for code convention, Assuming all account types should be in Account Namespace they should also be accounts
            //if they are all accounts then per the previous unit test they always have an owner.
            var t = typeof(Account);
            var types = t.Assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.Namespace.EndsWith("Accounts", StringComparison.CurrentCulture))
                {
                    Assert.IsTrue(type.IsSubclassOf(typeof(Account)));
                }
            }
        }

        
    }
}
