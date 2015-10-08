using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.UI.WorkFlows
{
    public class Withdraw
    {
        public void Execute(Account AccountInfo)
        {
            bool canWithdraw = false;
            do
            {
                decimal withdrawalAmount = PromptWithdrawalAmount();
                canWithdraw = SufficientFunds(AccountInfo, withdrawalAmount);

            } while (!canWithdraw);

            
        }

        public decimal PromptWithdrawalAmount()
        {
            //string input = "";
            //do
            //{
            //    Console.Clear();
            //    Console.Write("How much would you like to Withdrawal: ");
            //    Console.WriteLine();
            //    Console.WriteLine("Or press (Q) to Quit.");
            //    input = Console.ReadLine();

            //    decimal withdrawalAmount;
            //    if (decimal.TryParse(input, out withdrawalAmount))
            //    {
            //        return withdrawalAmount;
            //    }

            //    Console.WriteLine("That was not a valid amount...");
            //    Console.WriteLine("Press enter to continue...");
            //    Console.ReadLine();

            //} while (input.ToUpper() != "Q");

            Console.Clear();
            Console.Write("How much would you like to Withdrawal: ");
            Console.WriteLine();
            Console.WriteLine("Or press (Q) to Quit.");

            do
            {
                string input = Console.ReadLine();

                decimal withdrawalAmount;
                if (decimal.TryParse(input, out withdrawalAmount))
                {
                    return withdrawalAmount;
                }

                Console.WriteLine("That was not a valid amount...");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            } while (true);
        }

        public bool SufficientFunds(Account AccountInfo, decimal withdrawalAmount)
        {
            if (AccountInfo.Balance >= withdrawalAmount)
            {
                //decimal newBalance = AccountInfo.Balance - withdrawalAmount;
                return true;
            }
            Console.WriteLine("Insufficient Funds.");
            Console.ReadLine();
            return false;
        }
    }
}

