using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;

namespace SGBank.UI.WorkFlows
{
    public class AccountMenu
    {

        public void Execute(int AccountNumber)
        {
            var ops = new AccountOperations();
            var response = ops.GetAccount(AccountNumber);

            Account accountInformation = response.AccountInfo;

            string input = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Welcome {0} {1} to your SG Bank Account Menu!", response.AccountInfo.FirstName,
                    response.AccountInfo.LastName);
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("1. Make a Deposit");
                Console.WriteLine("2. Make a Withdrawal");
                Console.WriteLine("3. Transfer Money to Another User's Account");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input, accountInformation);
                }
            } while (input.ToUpper() != "Q");
        }

        public void ProcessChoice(string choice, Account AccountInfo)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("This feature is not implemented yet!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "2":
                    Withdraw withdrawal = new Withdraw();
                    withdrawal.Execute(AccountInfo);
                    break;
                case "3":
                    Console.WriteLine("This feature is not implemented yet!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("{0} is an invalid entry!", choice);
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
