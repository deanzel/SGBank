using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Account _currentAccount;

        public void Execute()
        {
            //bool accountExists = false;

            //int accountNum = VerifiedAccountNumber();

            int accountNumber = GetAccountNumberFromUser();
            DisplayAccountInformation(accountNumber);



            ////Then continue to Account Menu of that specific account
            //if (accountExists)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Press enter to continue to your SG Bank Account Menu...");
            //    Console.ReadLine();
            //    AccountMenu accountMenu = new AccountMenu();
            //    accountMenu.Execute(accountNumber);
            //}

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
                _currentAccount = response.AccountInfo;

                PrintAccountInformation(response.AccountInfo);
                Console.ReadLine();

                DisplayAccountMenu();
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

        public void DisplayAccountMenu()
        {
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Transfer");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }


            } while (input.ToUpper() != "Q");
        }

        public void ProcessChoice(string Choice)
        {
            switch (Choice)
            {
                case "1":
                    var depositWF = new DepositWorkFlow();
                    depositWF.Execute(_currentAccount);
                    PrintAccountInformation(_currentAccount);
                    DisplayAccountMenu();
                    break;
                case "2":
                case "3":
                    Console.WriteLine("This feature is not implemented!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid Entry...");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
