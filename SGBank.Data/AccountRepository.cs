using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class AccountRepository
    {
        private const string _filePath = @"DataFiles\Bank.txt";

        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();

            var reader = File.ReadAllLines(_filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var account = new Account();

                account.AccountNumber = int.Parse(columns[0]);
                account.FirstName = columns[1];
                account.LastName = columns[2];
                account.Balance = decimal.Parse(columns[3]);

                accounts.Add(account);
            }
            return accounts;
        }

        public Account GetAccount(int AccountNumber)
        {
            List<Account> accounts = GetAllAccounts();
            return accounts.FirstOrDefault(a => a.AccountNumber == AccountNumber);
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            var accounts = GetAllAccounts();

            var account = accounts.First(a => a.AccountNumber == accountToUpdate.AccountNumber);
            account.Balance = accountToUpdate.Balance;

            OverwriteFile(accounts);
        }

        public void OverwriteFile(List<Account> accounts)
        {
            File.Delete(_filePath);

            using (var writer = File.CreateText(_filePath))
            {
                writer.WriteLine("AccountNumber,FirstName,LastName,Balance");

                foreach (var account in accounts)
                {
                    writer.WriteLine("{0},{1},{2},{3}", account.AccountNumber, account.FirstName, account.LastName, account.Balance);
                }
            }
        }
    }
}
