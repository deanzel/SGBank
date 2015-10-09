using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.BLL
{
    public class AccountOperations
    {
        public Response GetAccount(int AccountNumber)
        {
            var repo = new AccountRepository();
            var response = new Response();

            var account = repo.GetAccount(AccountNumber);

            if (account == null)
            {
                response.Success = false;
                response.Message = "This is not the Account you are looking for...";
            }
            else
            {
                response.Success = true;
                response.AccountInfo = account;
            }

            return response;
        }

        public Response Deposit(Account account, decimal Amount)
        {
            var response = new Response();

            if (Amount > 0)
            {
                account.Balance += Amount;
                var repo = new AccountRepository();
                repo.UpdateAccount(account);

                response.Success = true;
                response.Message = "You have successfully made a deposit.";
                response.DepositInfo = new DepositSlip();
                response.DepositInfo.AccountNumber = account.AccountNumber;
                response.DepositInfo.DepositAmount = Amount;
                response.DepositInfo.NewBalance = account.Balance;

            }
            else
            {
                response.Success = false;
                response.Message = "WTF You have to give a positive amount to deposit!";
            }


            return response;
        }

        public Response Withdraw(Account account, decimal Amount)
        {
            var response = new Response();

            if (Amount <= account.Balance && Amount > 0)
            {
                account.Balance -= Amount;
                var repo = new AccountRepository();
                repo.UpdateAccount(account);

                response.Success = true;
                response.Message = "You have successfully made a withdrawal.";
                response.WithdrawalInfo = new WithdrawalSlip();
                response.WithdrawalInfo.AccountNumber = account.AccountNumber;
                response.WithdrawalInfo.WithdrawalAmount = Amount;
                response.WithdrawalInfo.NewBalance = account.Balance;
            }
            else
            {
                response.Success = false;
                if (Amount > account.Balance)
                {
                    response.Message = "You cannot withdraw more money than you have in your balance!!";
                }
                else
                {
                    response.Message = "That is not a proper withdrawal amount.";
                }
            }

            return response;
        }

        public Response Transfer(Account Account1, Account Account2, decimal Amount)
        {
            var response = new Response();

            if (Amount <= Account1.Balance && Amount > 0)
            {
                Account1.Balance -= Amount;
                Account2.Balance += Amount;
                var repo = new AccountRepository();
                repo.UpdateAccount(Account1, Account2);

                response.Success = true;
                response.Message = "You have successfully made a transfer.";
                response.TransferInfo = new TransferSlip();
                response.TransferInfo.CurrentAccountNumber = Account1.AccountNumber;
                response.TransferInfo.CurrentAccountName = Account1.FirstName + " " + Account1.LastName; 
                response.TransferInfo.TargetAccountNumber = Account2.AccountNumber;
                response.TransferInfo.TargetAccountName = Account2.FirstName + " " + Account2.LastName;
                response.TransferInfo.TransferAmount = Amount;
                response.TransferInfo.NewBalanceCurrentAccount = Account1.Balance;
                response.TransferInfo.NewBalanceTargetAccount = Account2.Balance;
            }
            else
            {
                response.Success = false;
                if (Amount > Account1.Balance)
                {
                    response.Message = "You cannot transfer more money than you have in your balance!!";
                }
                else
                {
                    response.Message = "That is not a proper transfer amount.";
                }
            }

            return response;
        }
    }
}
