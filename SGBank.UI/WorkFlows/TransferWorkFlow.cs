using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.WorkFlows
{
    public class TransferWorkFlow
    {
        private Account _currentAccount;
        private Account _targetAccount;

        public void Execute(Account account)
        {
            _currentAccount = account;
            
            int targetAccountNumber = GetTargetAccountFromUser();
            bool targetAccountExists = DisplayTargetAccountInfo(targetAccountNumber);
            //decimal transferAmount;

            if (targetAccountExists)
            {
                decimal transferAmount = GetTransferAmountFromUser();
                MakeTransfer(transferAmount);
            }

        }

        public int GetTargetAccountFromUser()
        {
            do
            {
                Console.WriteLine("What account number do you want to transfer money to?");

                string input = Console.ReadLine();

                int targetAccountNumber;
                if (int.TryParse(input, out targetAccountNumber))
                {
                    return targetAccountNumber;
                }

                Console.WriteLine("That was not a valid account number...");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            } while (true);

        }

        public bool DisplayTargetAccountInfo(int AccountNumber)
        {
            var ops = new AccountOperations();
            var response = ops.GetAccount(AccountNumber);

            if (response.Success)
            {
                _targetAccount = response.AccountInfo;
                Console.WriteLine("We will be transfering money to {0} {1} with Account Number {2} and a current balance of {3}.", _targetAccount.FirstName, _targetAccount.LastName, _targetAccount.AccountNumber, _targetAccount.Balance);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return true;
            }
            else
            {
                Console.WriteLine("Error Occurred!!");
                Console.WriteLine("This account does not exist.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return false;
            }
        }

        public decimal GetTransferAmountFromUser()
        {
            do
            {
                Console.WriteLine("Enter how much you would like to transfer to {0} {1}: ", _targetAccount.FirstName, _targetAccount.LastName);
                string input = Console.ReadLine();

                decimal transferAmount;
                if (decimal.TryParse(input, out transferAmount))
                {
                    return transferAmount;
                }

                Console.WriteLine("That was not a valid amount...");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            } while (true);
        }


        public void MakeTransfer(decimal Amount)
        {
            var ops = new AccountOperations();
            var response = ops.Transfer(_currentAccount, _targetAccount, Amount);

            if (response.Success)
            {
                Console.WriteLine();
                Console.WriteLine("Transfered {0:c} to {1}'s account (#{2}) from {3}'s account (#{4})",
                    response.TransferInfo.TransferAmount, response.TransferInfo.TargetAccountName,
                    response.TransferInfo.TargetAccountNumber, response.TransferInfo.CurrentAccountName,
                    response.TransferInfo.CurrentAccountNumber);
                Console.WriteLine("{0}'s New Balance: {1}", response.TransferInfo.CurrentAccountName,
                    response.TransferInfo.NewBalanceCurrentAccount);
                Console.WriteLine("{0}'s New Balance: {1}", response.TransferInfo.TargetAccountName,
                    response.TransferInfo.NewBalanceTargetAccount);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(response.Message);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
