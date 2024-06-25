using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25June
{
    public class DataStore<T>
    {
        public T record_code;
        public T record_uid;
        public DateTime CreationDate;
    }
    internal class Program
    {
        static void ReadData(ArrayList ar) // Generic Class - Strongly Typed Class
        {
            // Generic Collection - Strongly Typed Collection
            DataStore<int> dlist = new DataStore<int>();
            List<string> slist = new List<string>();
        }
        static void Main(string[] args)
        {


            /*Stack:
            Stack s1 = new Stack();
            Stack<int> s2 = new Stack<int>();

            s1.Push(1);
            s1.Push("Samir");
            s1.Push("10/10/2020");
            s1.Push('V');

            IEnumerator e1 = s1.GetEnumerator();
            while (e1.MoveNext())
            {
                Console.WriteLine(e1.Current);
            }
            e1.Reset();
            Console.WriteLine(e1.ToString());
            Console.WriteLine(e1.Equals('V'));
            Console.WriteLine();

            Console.WriteLine(s1.ToString());
            Console.WriteLine(s1.Count);
            Console.WriteLine();

            Console.WriteLine(s1.Peek());
            Console.WriteLine(s1.Count);
            Console.WriteLine();

            Console.WriteLine(s1.Pop());
            Console.WriteLine(s1.Count); 
            Console.WriteLine();

            s1.Clear();
            Console.WriteLine(s1.ToString());
            Console.WriteLine(s1.Count);
            Console.WriteLine();

            s1.Push("101");
            s1.Push("102");
            s1.Push("201");
            s1.Push("202");
            Console.WriteLine();*/

            Console.ReadLine();
        }
    }
}
