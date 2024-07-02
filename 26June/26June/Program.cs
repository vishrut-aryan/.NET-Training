using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _26June
{
    public class IMaths
    {
        public static void Add(int n1, int n2)
        {
            Console.WriteLine(n1 + n2);
        }
        public static void Subtract(int n1, int n2)
        {
            Console.WriteLine(n1 - n2);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public Person(string name, int age, string sex)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
    }

    public class Print
    {
        public void PrintJob(object data)
        {
            Console.WriteLine("Background PrintJob started.");
            Thread.Sleep(1000);
            Console.WriteLine("PrintJob still printing...");
            Console.WriteLine($"Data: {data}");
            Thread.Sleep(1000);
            Console.WriteLine("PrintJob finished.");
        }

        public void PrintPerson(object data)
        {
            Console.WriteLine("Background PrintPerson started.");
            Thread.Sleep(1000);
            Console.WriteLine("PrintPerson still printing...");
            Person p = (Person)data;
            Console.WriteLine($"Person {p.Name} is a {p.Sex} of {p.Age} age.");
            Thread.Sleep(1000);
            Console.WriteLine("PrintPerson finished.");
        }
    }

    internal class Program
    {
        public static object monitorobj = new object();

        public static async void PrintEvenAsync()
        {
            for (int i = 2; i <= 10; i = i + 2) { Console.WriteLine("Even: " + i); await Task.Delay(1000); }
            Console.WriteLine("Process PrintEven Done");
        }

        public static async void PrintOddAsync()
        {
            for (int i = 1; i <= 10; i = i + 2) { Console.WriteLine("Odd: " + i); await Task.Delay(1000); }
            Console.WriteLine("Process PrintOdd Done");
        }

        public static void PrintEven()
        {
            Monitor.Enter(monitorobj);

            for (int i = 2; i <= 10; i = i+2) { Console.WriteLine("Even: " + i); Thread.Sleep(1000); }
            Console.WriteLine("Process PrintEven Done");
            Thread.Sleep(2000);

            Monitor.Exit(monitorobj);
        }

        public static void PrintOdd()
        {
            Monitor.Enter(monitorobj);

            for (int i = 1; i <= 10; i = i+2) { Console.WriteLine("Odd: " + i); Thread.Sleep(1000); }
            Console.WriteLine("Process PrintOdd Done");
            Thread.Sleep(2000);

            Monitor.Exit(monitorobj);
        }

        public static void PrintFile()
        {

        }

        static void SendMail(string emailID)
        {
            string smtpname = "smtp.gmail.com";
            string usrname = "aryan.vishrut@gmail.com";
            string pwd = "";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(usrname, "Vishrut Aryan");
            message.To.Add(emailID);
            //message.CC.Add(txtcc.Text.Trim());
            message.Body = "";
            message.Priority = MailPriority.High;
            //message.Attachments.Add(new Attachment(files));
            message.IsBodyHtml = true;
            NetworkCredential loginInfo = new NetworkCredential(usrname, pwd);
            SmtpClient client = new SmtpClient(smtpname);
            client.Port = 587;
            //client.Port = 465;
            client.EnableSsl = true; //commented for thrifty
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.Send(message);

            message.Dispose();
        }

        static void Main(string[] args)
        {
        THREADING:

            Thread t1 = new Thread(PrintOddAsync);
            Thread t2 = new Thread(PrintEvenAsync);
            t1.Start();
            t2.Start();

            if (t1.ThreadState == ThreadState.Suspended) 
            {
                Console.WriteLine("Hi");
                Thread t3 = new Thread(PrintEvenAsync);
                Thread t4 = new Thread(PrintEvenAsync);
                t3.Start();
                t4.Start();
            }

            if (t2.ThreadState == ThreadState.Stopped)
            {
                Console.WriteLine("Hi");
                Thread t5 = new Thread(PrintEvenAsync);
                Thread t6 = new Thread(PrintEvenAsync);
                t5.Start();
                t6.Start();
            }

            /*Thread even1 = new Thread(PrintEven);
            Thread even2 = new Thread(PrintEven);
            even1.Priority = ThreadPriority.AboveNormal;
            even2.Priority = ThreadPriority.Lowest;
            even1.Start();
            even2.Start();*/

            /*Thread t1 = new Thread(PrintOdd);
            Thread t2 = new Thread(PrintEven);
            t1.Start();
            t2.Start();
            //if ((t1.IsBackground) && (t2.IsBackground)) { goto THREADING; }

            Print p = new Print();
            Thread t = new Thread(p.PrintJob);
            t.Start("Some Data");

            Person p1 = new Person("Alue", 18, "Male");
            Thread tt = new Thread(p.PrintPerson);
            tt.Start(p1);*/



            /*Doubts:
            string str = "Welcome to Holtec Asia, Pune Branch. ";
            string revstr = (string)str.Reverse();
            string normstr = str.Normalize();
            string lowstr = str.ToLower();
            string substr = str.Substring(-3, 7);
            string[] strs = str.Split(' ');
            if (str.CompareTo("welcome") >= 0) { }
            if (str.Contains("si")) { }
            char[] ch = str.ToCharArray();
            string trimstr1 = str.TrimStart('A');
            string trimstr2 = str.Trim();
            str.Concat("Hi, I am Vishrut Aryan. ");
            
            ArrayList ar = new ArrayList();
            ar.Add(100);
            ar.Add(200);
            ar.Add(300);
            ar.Add("Vishrut");
            ar.Add("Aryan");
            ar.Remove(100);
            ar.RemoveAt(3);
            if (ar.Contains("Vishrut")) { }*/


            /*IMaths m1 = new IMaths();
            ArrayList arr = new ArrayList();
            arr.Add(100);
            arr.Add(200);

            
            IEnumerable e1 = (IEnumerable)arr.GetEnumerator();
            foreach (var item in e1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            IQueryable q1 = e1.AsQueryable();
            IQueryable<int> q2 = (IQueryable<int>)arr.GetEnumerator();
            foreach (var item in q1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in q2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();*/


            Console.ReadLine();
        }
    }
}
