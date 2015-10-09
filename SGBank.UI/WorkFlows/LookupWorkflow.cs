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
            int accountNumber = GetAccountNumberFromUser();
            DisplayAccountInformation(accountNumber);


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
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            } while (true);
        }

        public void DisplayAccountInformation(int AccountNumber)
        {
            var ops = new AccountOperations();
            var response = ops.GetAccount(AccountNumber);


            if (response.Success)
            {
                _currentAccount = response.AccountInfo;

                PrintAccountInformation(response.AccountInfo);
                Console.ReadLine();

                DisplayAccountMenu();
                
                
            }
            else
            {
                Console.WriteLine("Error Occurred!!!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            }

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
                Console.WriteLine("Welcome {0} {1} to your SG Bank Account Menu!", _currentAccount.FirstName, _currentAccount.LastName);
                Console.WriteLine("-----------------------------------------------------------------");
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
                    var withdrawWF = new WithdrawWorkFlow();
                    withdrawWF.Execute(_currentAccount);
                    PrintAccountInformation(_currentAccount);
                    DisplayAccountMenu();
                    break;
                case "3":
                    var transferWF = new TransferWorkFlow();
                    transferWF.Execute(_currentAccount);
                    PrintAccountInformation(_currentAccount);
                    DisplayAccountMenu();
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
