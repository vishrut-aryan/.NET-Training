using System;

namespace _20June
{
    internal partial class BankAcc
    {
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
}