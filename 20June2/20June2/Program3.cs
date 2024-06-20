using _20June;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20June
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            BankAcc acc = new BankAcc();

            string y = "Y";
            do
            {
                Console.WriteLine("Would you like to Credit or Debit?");
                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "Credit")
                {
                    Console.WriteLine("Enter amount to be credited");
                    acc.Credit(Convert.ToDouble(Console.ReadLine()));
                }
                else if (choice == "Debit")
                {
                    Console.WriteLine("Enter amount to be Debited");
                    acc.Debit(Convert.ToDouble(Console.ReadLine()));
                }
                else { Console.WriteLine("Invalid Choice"); }

                Console.WriteLine("Would you like to make another transaction? Enter Y to continue");
                y = Console.ReadLine().ToUpper();
                Console.WriteLine();
            }
            while (y == "Y");

            Console.WriteLine("Would you like to check final balance? Enter Y if yes");
            string ch = Console.ReadLine();
            if (ch == "Y")
            {
                Console.WriteLine(acc.BankBalance);

            }
            Console.WriteLine();

            Console.WriteLine("Would you like to change Account No? Enter Y if yes");
            ch = Console.ReadLine();
            if (ch == "Y")
            {
                acc.NoSetter = Console.ReadLine();
            }
            Console.WriteLine();

            Console.WriteLine("Would you like to change Account Name? Enter Y if yes");
            ch = Console.ReadLine();
            if (ch == "Y")
            {
                acc.NameSetter = Console.ReadLine();
            }
            Console.WriteLine();

            Console.ReadLine();

            //Rectangle r = new Rectangle();
        }
    }
}
