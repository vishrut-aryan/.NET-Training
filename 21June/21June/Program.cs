using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21June
{
    public static class Config
    {
        public static string filepath = @"D:\Data\";
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

    internal class Program
    {
        static void Main(string[] args)
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

            Console.ReadLine();
        }
    }
}
