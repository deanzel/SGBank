using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.WorkFlows
{
    public class MainMenu
    {
        public void Execute()
        {
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO SG BANK!");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Delete Account");
                Console.WriteLine("3. Lookup Account");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }

            } while (input.ToUpper() != "Q");
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                case "2":
                    Console.WriteLine("This feature is not implemented yet!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
                case "3":
                    LookupWorkflow lwf = new LookupWorkflow();
                    lwf.Execute();
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
