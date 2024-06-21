using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21June
{
    public static class Config
    {
        public static string filepath = @"D:\Data\";  // '\' this slash gives .NET an error, so the '@' is required or '\\' to still display the required output
        static string servername = "localhost";

        public static void Display()
        {
            Console.WriteLine("Server Name:       " + servername);
        }
    }

    public class static_method
    {
        public int counter;
        public static int scounter;

        public void counting()
        {
            counter += 1;
            scounter += 1;
        }
    }

    public class static_data_member
    {
        public int counter;
        public static int scounter;

        public static_data_member() 
        {
            counter += 1;
            scounter += 1;
        }
    }

    public class Holtec
    {
        public int RegNo;
        public int EmpCount;

        public Holtec()
        {
            Console.WriteLine("Default Constructor");
            Console.WriteLine("");
        }

        public Holtec(int x)
        {
            Console.WriteLine("Parameterized Constructor");
            Console.WriteLine("");
            privatized();
        }

        static Holtec()
        {
            Console.WriteLine("Static Constructor");
            Console.WriteLine("");
        }

        private Holtec(int x, int y)
        {
            Console.WriteLine("Private Constructor");
            Console.WriteLine("");
        }

        public Holtec(Holtec h)
        {
            Console.WriteLine("Copy Constructor");
            Console.WriteLine("");
        }

        public void privatized() { Holtec h5 = new Holtec(10, 10); }
    }
    
    internal sealed class Static
    {
        public static void _static()
        {
            static_data_member emp1 = new static_data_member();
            static_data_member emp2 = new static_data_member();
            static_data_member emp3 = new static_data_member();

            Console.WriteLine("Static Data Member");
            Console.WriteLine("Nonstatic counter: " + emp3.counter);
            Console.WriteLine("Static counter:    " + static_data_member.scounter);
            Console.WriteLine("");

            static_method sm1 = new static_method();
            static_method sm2 = new static_method();
            sm1.counting();
            sm1.counting();
            sm2.counting();

            Console.WriteLine("Static Method");
            Console.WriteLine("Nonstatic counter: " + sm1.counter + ", " + sm2.counter);
            Console.WriteLine("Static counter:    " + static_method.scounter);
            Console.WriteLine("");

            Console.WriteLine("Static Class");
            Console.WriteLine("File Path:         " + Config.filepath);
            Config.Display();
            Console.WriteLine("");
        }

        public static void Main(string[] args)
        {
            //Static._static();

            //Inherit.inherit();

            //Inherit.powertwo();
            //Inherit.powerfour();
            //Inherit.powersixteen();

            //Inherit.timestwo(7);
            //Inherit.timesthree(7);
            //Inherit.timesfour(7);

            //interfacing i1 = new interfacing();
            //i1.Display();

            //StudentMarks studentMarks = new StudentMarks();
            //studentMarks.Display();

            Holtec h1 = new Holtec();
            Holtec h2 = new Holtec(10);
            Holtec h3 = new Holtec(h1);

            Console.ReadLine();
        }
    }
}
