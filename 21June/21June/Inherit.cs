using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21June
{
    public class Parent
    {
        public int a;
        public int num = 7;
        public int n;

        public Parent() { }
        public Parent(int n) { Console.WriteLine("Hello Child"); }

    }

    public class Child : Parent 
    {
        public int b;

        public Child() { a = 10; num = num * num; }
        public Child(int n) : base(n) { num += n; Console.WriteLine("Hello Grand Child"); }
    }

    public class Grandchild : Child
    {
        public int c;

        public Grandchild() { b = 20; num = num * num; }
        public Grandchild(int n) : base(n) { num += n; Console.WriteLine("Hello Great Grand Child"); }
    }

    public class Greatgrandchild : Grandchild
    {
        public int d = 40;
        public Greatgrandchild() { c = 30; num = num * num; }
        public Greatgrandchild(int n) : base(n) { num += n; Console.WriteLine("Hello Great Great Grand Child"); }
    }


    public class Inherit
    {
        public static void inherit ()
        {
            Greatgrandchild gr = new Greatgrandchild();
            gr.c = gr.a + gr.b;
            gr.d = gr.c + gr.b + gr.a;
            Console.WriteLine("a = " + gr.a);
            Console.WriteLine("b = " + gr.b);
            Console.WriteLine("c = " + gr.c);
            Console.WriteLine("d = " + gr.d);
            Console.WriteLine("");
        }

        public static void powertwo()
        {
            Child g = new Child();
            Console.WriteLine("7 to the power 2 is  " + g.num);
            Console.WriteLine("");
        }

        public static void powerfour()
        {
            Grandchild g = new Grandchild();
            Console.WriteLine("7 to the power 4 is " + g.num);
            Console.WriteLine("");
        }

        public static void powersixteen()
        {
            Greatgrandchild g = new Greatgrandchild();
            Console.WriteLine("7 tto the power 16 is " + g.num);
            Console.WriteLine("");
        }

        public static void timestwo(int n)
        {
            Child g = new Child(n);
            Console.WriteLine("7 times 2 is " + g.num);
            Console.WriteLine("");
        }

        public static void timesthree(int n)
        {
            Grandchild g = new Grandchild(n);
            Console.WriteLine("7 times 3 is " + g.num);
            Console.WriteLine("");
        }

        public static void timesfour(int n)
        {
            Greatgrandchild g = new Greatgrandchild(n);
            Console.WriteLine("7 times 4 is " + g.num);
            Console.WriteLine("");
        }
    }
}
