using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace _25June
{
    public class DataStore<T> // Class as Strongly Typed Collection
    {
        public T record_code;
        public T record_uid;
        public DateTime CreationDate;
    }

    public static class Ext  // Extension Methods
    {
        public static int Word_Count(this string s, string words)  // Existing Method Extension
        {
            int count = 1;

            string[] wordList = words.Split(' ');
            count = wordList.Length;

            foreach (string word in wordList) { Console.WriteLine(word); }
            Console.WriteLine();

            /*foreach (char c in words)
            {
                if (c == ' ')
                    count++;
            }*/

            return count;
        }

        public static void LogError(this Exception ex1, string errname)  // Custom Exception Extension
        {
            FileStream fs = new FileStream(@"ErrorLog.txt", FileMode.Append);
            StreamWriter str = new StreamWriter(fs);

            str.WriteLine("Error Occured in {0} at {1}", errname, System.DateTime.Now.ToString());
            str.WriteLine(ex1.Message);
            str.WriteLine();

            str.Close();
            fs.Close();

            Console.WriteLine(errname);
            Console.WriteLine(ex1.Message);
        }
    }

    public delegate void dlg(int n1, int n2);

    internal class Program
    {
        static void ReadData(ArrayList ar) // Generic Class - Strongly Typed Class
        {
            // Generic Collection - Strongly Typed Collection
            DataStore<int> dlist = new DataStore<int>();
            List<string> slist = new List<string>();
        }

        static void add(int n1, int n2) { Console.WriteLine(n1 + n2); }
        static void subtract(int n1, int n2) { Console.WriteLine(n1 - n2); }


        public static void Event(dlg d) 
        {
            dlg d1 = new dlg(add);
            dlg d2 = new dlg(subtract);
            d1.Invoke(6, 5);
            d2.Invoke(6, 5);

            d(200, 100);
        }

        static void Main(string[] args)
        {
            dlg d0 = new dlg (add);
            d0 += new dlg(subtract);
            Event(d0);

            //string words = "Hi, I am Vishrut Aryan!";
            //Console.WriteLine(words.Word_Count(words));

            /*try
            {
                Queue<int> qlist1 = new Queue<int>();
                qlist1.Enqueue(1);
                qlist1.Enqueue(2);
                qlist1.Enqueue(3);
                qlist1.Enqueue(4);
                qlist1.Enqueue(5);
                List<int> qlist2 = qlist1.ToList();


                Queue qlist = new Queue();
                qlist.Enqueue("Vishrut");
                qlist.Enqueue(280);

                foreach (object o in qlist)
                {
                    System.Console.WriteLine(o);
                }
                Console.WriteLine();

                object o1 = qlist.Dequeue();
                Console.WriteLine(o1);
                Console.WriteLine();

                throw new Exception("We trying to do a thing");
            }
            catch (Exception ex) 
            {
                ex.LogError("HOLTEC-APP");
            }*/

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
