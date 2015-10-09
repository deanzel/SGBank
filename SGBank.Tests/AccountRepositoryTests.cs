using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.Tests
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        [Test]
        public void CanLoadAccount()
        {
            var repo = new AccountRepository();

            var account = repo.GetAccount(1);

            Assert.AreEqual(1, account.AccountNumber);
            Assert.AreEqual("Mary", account.FirstName);
        }

        [Test]
        public void WriteNewAccount()
        {
            Account account = new Account();
            account.FirstName = "Dean";
            account.LastName = "Choi";
            account.Balance = 1000000.00M;

            var repo = new AccountRepository();

            var accounts = repo.GetAllAccounts();
            var numAccounts = accounts.Count;

            repo.WriteNewLine(account);

            var accountsAfterAdd = repo.GetAllAccounts();
            var numAccountsAfterAdd = accountsAfterAdd.Count;

            Assert.AreEqual(numAccounts + 1, numAccountsAfterAdd);
        }
    }
}
