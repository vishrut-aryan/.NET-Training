using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class Threads
    {
        public static void method1()
        {

            for (int I = 0; I <= 10; I++)
            {
                Console.WriteLine("Method1 is : {0}", I);
                //Thread.Sleep(1000);

                if (I == 5)
                {
                    Thread.Sleep(2000);
                }
            }
        }

        public static void method2()
        {
            for (int J = 0; J <= 10; J++)
            {
                Console.WriteLine("Method2 is : {0}", J);
                //Thread.Sleep(1000);
            }
        }

        static public void Main()
        {
            // Single Threaded
            //method1();
            //method2();

            // Multi Threaded
            Thread thr1 = new Thread(method1);
            Thread thr2 = new Thread(method2);
            thr1.Start();
            thr2.Start();

            Console.ReadLine();
        }
    }
}