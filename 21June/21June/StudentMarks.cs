using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21June
{
    interface student_template
    {
        void input_math(string x);
        void input_sci(string x);
        void input_eng(string x);
        string input_name();
        void calculate_marks(double x, double y, double z);
        void calculate_grade(double x);
        void Display();
    }

    public class StudentMarks : student_template
    {
        double math, eng, sci, total, per;
        string name, grade;
        public void input_math(string name)
        {
            Console.WriteLine("Please enter " + name + "'s Maths marks: ");
            math = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("");
        }
        public void input_sci(string name)
        {
            Console.WriteLine("Please enter " + name + "'s  Science marks: ");
            sci = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("");
        }
        public void input_eng(string name)
        {
            Console.WriteLine("Please enter  " + name + "'s English marks: ");
            eng = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("");
        }
        public string input_name()
        {
            Console.WriteLine("Please enter Student Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("");
            return name;
        }
        public void calculate_marks(double x, double y, double z)
        {
            total = math + eng + sci;
            per = total / 3;
        }

        public void calculate_grade(double per)
        {
            if (per > 90) { Console.WriteLine("Grade received is O"); }
            else if (per > 70) { Console.WriteLine("Grade received is A"); }
            else if (per > 50) { Console.WriteLine("Grade received is B"); }
            else if (per > 30) { Console.WriteLine("Grade received is C"); }
            else { Console.WriteLine("Grade received is Failure"); }
            Console.WriteLine("");
        }
        public void Display()
        {
            string name = input_name();
            input_eng(name);
            input_math(name);
            input_sci(name);
            calculate_marks(eng, math, sci);
            calculate_grade(per);
        }
    }
}
