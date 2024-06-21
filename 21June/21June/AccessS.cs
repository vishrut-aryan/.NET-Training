using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21June
{
    interface minimal
    {
        double square(double x);
        double cube(double x);
        void minimal();
    }
    public class test : minimal
    {
        public void minimal () {}

        public double square (double a) 
        {
            return a * a;
        }
        public double cube(double a)
        {
            return a * a * a;
        }
    }

    public class interfacing
    {
        public void Display()
        {
            test t1 = new test();

            Console.WriteLine("The square is " + t1.square(8));
            Console.WriteLine("The square is " + t1.cube(8));
        }
    }
}
