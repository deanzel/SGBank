using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.WorkFlows
{
    public class LookupWorkflow
    {
        public void Execute()
        {
            bool accountExists = false;

            //int accountNum = VerifiedAccountNumber();

            int accountNumber = GetAccountNumberFromUser();
            accountExists = DisplayAccountInformation(accountNumber);



            //Then continue to Account Menu of that specific account
            if (accountExists)
            {
                Console.WriteLine();
                Console.WriteLine("Press enter to continue to your SG Bank Account Menu...");
                Console.ReadLine();
                AccountMenu accountMenu = new AccountMenu();
                accountMenu.Execute(accountNumber);
            }

        }

        public int GetAccountNumberFromUser()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter an account number: ");
                string input = Console.ReadLine();

                int accountNumber;
                if (int.TryParse(input, out accountNumber))
                {
                    return accountNumber;
                }

                Console.WriteLine("That was not a valid account number...");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();

            } while (true);
        }

        public bool DisplayAccountInformation(int AccountNumber)
        {
            var ops = new AccountOperations();
            var response = ops.GetAccount(AccountNumber);


            if (response.Success)
            {
                PrintAccountInformation(response.AccountInfo);
                Console.ReadLine();
                
                return true;
            }
            else
            {
                Console.WriteLine("Error Occurred!!!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
                return false;
            }
            //return response.AccountInfo;
        }

        public void PrintAccountInformation(Account AccountInfo)
        {
            Console.WriteLine("Account Information");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Account Number: {0}", AccountInfo.AccountNumber);
            Console.WriteLine("Name: {0}, {1}", AccountInfo.LastName, AccountInfo.FirstName);
            Console.WriteLine("Account Balance: {0:c}", AccountInfo.Balance);
            
        } 



    }
}
