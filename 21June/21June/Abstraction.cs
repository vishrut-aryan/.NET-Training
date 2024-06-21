using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21June
{
    public abstract class Abstraction : minimal
    {
        public double num;
        public double total;

        public Abstraction() 
        {
            Console.WriteLine("Enter a number");
            num = Convert.ToDouble(Console.ReadLine());
        }

        public double square(double x)
        {
            total = num * num;
            Console.WriteLine(total);
            return x;
        }

        public abstract double cube(double x);

        public abstract void minimal();
    }

    public class New_abstract : Abstraction
    {
        public override double cube(double x)
        {
            total = num * num * num;
            Console.WriteLine(total);
            return x;
        }

        public override void minimal() { }
    }
}
