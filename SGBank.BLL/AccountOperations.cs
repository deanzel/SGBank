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
        

    }
}
