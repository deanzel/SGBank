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


    }
}
