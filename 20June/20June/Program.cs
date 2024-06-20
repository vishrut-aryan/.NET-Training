using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20June
{
    public class Student
    {
        private string name = "Aryan";
        private double marks1;
        private double marks2;
        private double marks3;
        private double totalmarks;
        private double per;

        public void GetStudents()
        {
            Console.WriteLine("Enter Student Name: ");
            name = Console.ReadLine();
        }

        public void GetStudents(string name)
        {
            this.name = name;
        }
    }

    public class Employee   // by default public or internal
    {
        public int emp_id;        // object
        private string name;
        private int salary; // by default private
        private int tax;
        public static string company_name = "Holtec Asia";   // class/static

        public void Display()
        {
            Console.WriteLine("Employee ID: " + emp_id);
            for (int i = 0; i < emp_id; i++)                 // local
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }

    public class Students
    {
        public string StudentName;
        public double EngMarks;
        public double SciMarks;
        public double MathMarks;
        public double TotalMarks;
        public double Per;

        public void calc_marks()
        {
            if (StudentName == null)
            {
                Console.WriteLine("Please enter Student Name: ");
                StudentName = Console.ReadLine();
                Console.WriteLine();
            }

            if (SciMarks == 0 && MathMarks == 0 && EngMarks == 0)
            {
                Console.WriteLine("Please enter Student Maths Marks: ");
                MathMarks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Student Eng Marks: ");
                EngMarks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter Student Sci Marks: ");
                SciMarks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }

            TotalMarks = SciMarks + EngMarks + MathMarks;
            Console.WriteLine(StudentName + "'s total marks is " + TotalMarks);
            Per = TotalMarks / 3;
            Console.WriteLine(StudentName + "'s percentage is " + Per);
            Console.ReadLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.GetStudents();
            s1.GetStudents("Vishrut");





            /*Console.WriteLine(Employee.company_name);
            Employee.company_name = "Holtec International";
            Console.WriteLine(Employee.company_name);

            Employee e1 = new Employee();
            e1.Display();*/

            
            
            
            
            /*Students s1 = new Students();
            s1.StudentName = "Aryan";
            s1.SciMarks = 88;
            s1.MathMarks = 92;
            s1.EngMarks = 70;
            s1.calc_marks();

            Students s2 = new Students();
            s2.calc_marks();*/

        }
    }
}
