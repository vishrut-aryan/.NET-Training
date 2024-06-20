using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20June
{
    internal partial class BankAcc
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
            get { return acc_name; }
        }

        public string NoSetter
        {
            set { acc_no = value; }
            get { return acc_no; }
        }
    }
}
