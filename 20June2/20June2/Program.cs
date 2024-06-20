using System;

namespace _20June2
{
    public class BankAcc
    {
        private string acc_no;
        private string acc_name;
        private double bal = 5000;

        public BankAcc()
        {
            Console.WriteLine("Please enter Account Number: ");
            acc_no = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter Account Name: ");
            acc_name = Console.ReadLine();
            Console.WriteLine();
        }

        public double BankBalance
        {
            get { return bal; } 
        }

        public string NameSetter
        {
            set { acc_name = value; }
        }

        public string NoSetter
        {
            set { acc_no = value; }
        }

        public void Debit(double amount)
        {
            if(amount > (bal - 5000))
            {
                Console.WriteLine("Insufficient Balance, please maintain minimum balance of 5000!");
                return;
            }

            bal -= amount;
            Console.WriteLine("New Balance is {0}", bal);
            Console.WriteLine();
        }

        public void Credit(double amount)
        {
            if(amount > 500000)
            {
                Console.WriteLine("Suspiscious Transanction, more than 5 Lakh rupees entered!");
                return;
            }

            bal += amount;
            Console.WriteLine("New Balance is {0}", bal);
            Console.WriteLine();
        }
    }
    public class Rectangle
    {
        private double length;
        private double width;
        private double area;

        public Rectangle()
        {
            Console.WriteLine("Enter Length: ");
            length = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Width: ");
            width = Convert.ToDouble(Console.ReadLine());

            area = length * width;
            Console.WriteLine("Area: " + area);
            Console.ReadLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAcc acc = new BankAcc();

            string y = "Y";
            do {
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