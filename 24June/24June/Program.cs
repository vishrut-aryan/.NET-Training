using ExceptionExp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24June
{
    public class Marks
    {
        public double Eng, Scn, Maths, Total, Per, salary;
    }

    public class Student:Marks
    {
        public void Calculate()
        {
            Console.WriteLine("Enter English marks: ");
            Eng = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Science marks: ");
            Scn = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Maths marks: ");
            Maths = Convert.ToDouble(Console.ReadLine());
            Total = Eng + Scn + Maths;
            Per = Total / 3;
            return;
        }

        public void getGrade(double Per1, out string Grade) // output parameters
        {
            if (Per1 > 90)
            {
                Grade = "Distinction";
            }
            else if (Per1 > 70)
            {
                Grade = "First Class";
            }
            else if (Per1 > 50)
            {
                Grade = "Second Class";
            }
            else
            {
                Grade = "Fail";
            }
        }

        public void salarycalc(out double pf, out double tax)
        {
            Console.WriteLine("What is Employee's Salary?");
            salary = Convert.ToDouble(Console.ReadLine());

            tax = 0.2 * salary;
            pf = 0.12 * salary;
        }
    }

    public class Calc
    {
        public void Div() 
        {
            try
            {
                Console.WriteLine("Enter numerator: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter denominator: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                if (num1 == 0 || num2 ==0)
                    throw new Exception("Number cannot be zero");
                Console.WriteLine();

                int num3 = num1 / num2;
                Console.WriteLine("Divison is " + num3);
                Console.ReadLine();
                Console.WriteLine();
            }
            catch (Exception ex1) { throw ex1; }
        }
    }

    enum GRADE
    {
        DISTINCTION = 75,
        FIRSTCLASS = 60,
        SECONDCLASS = 40,
        FAIL
    }

    internal class Program
    {
        static void Cal(ArrayList ar, Hashtable hst)
        {
            bankacc bb1 = (bankacc)hst[101];
            Console.WriteLine(bb1._accname);
            Console.WriteLine(bb1._balance);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
        COLLECTION:
            ArrayList arr = new ArrayList();
            arr.Add(100);
            arr.Add(100.001);
            arr.Add('V');
            arr.Add("Aryan");
            arr.Add(true);
            bankacc bacc = new bankacc();
            arr.Add(bacc);

            ArrayList arr2 = new ArrayList();
            arr2.Add(arr[0]);
            arr2.Add(arr);

            bankacc bacc2 = (bankacc)arr[5];

            Hashtable hst = new Hashtable();
            hst.Add(101, bacc);
            hst.Add(102, "Vishrut");

            Cal(arr, hst);
            bankacc bacc3 = (bankacc)hst[101];


            for (int i = 0; i < arr.Count; i = i + 1)
                Console.WriteLine("Element at position {0} is {1}", i, arr[i]);
            Console.WriteLine();

            for (int i = 0; i < arr2.Count; i = i + 1)
                Console.WriteLine("Element at position {0} is {1}", i, arr2[i]);
            Console.WriteLine();

            for (int i = 0; i < hst.Count; i = i + 1)
                Console.WriteLine("Element at position {0} is {1}", i, hst[i + 101]);
            Console.WriteLine();

            /*ARRAYS:
                int[] nums = new int [10];
                nums[0] = 10;
                for (int i = 0; i < nums.Length; i = i + 1)
                    Console.WriteLine("Element at position {0} is {1}", i, nums[i]);*/

            /*ENUMS:
                try
                {
                    Console.WriteLine("Enter Percentage: ");
                    double per = Convert.ToDouble(Console.ReadLine());

                    if (per >= (int) GRADE.DISTINCTION)
                        Console.WriteLine(GRADE.DISTINCTION);
                    else if (per >= (int) GRADE.FIRSTCLASS)
                        Console.WriteLine(GRADE.FIRSTCLASS);
                    else if (per >= (int)GRADE.SECONDCLASS)
                        Console.WriteLine(GRADE.SECONDCLASS);
                    else
                        Console.WriteLine(GRADE.FAIL);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                Console.WriteLine();

                if (Console.ReadLine().ToLower() != "quit")
                    goto ENUMS;*/

            /*EH3:
                bankacc ba = new bankacc();
                Console.WriteLine();
                if (Console.ReadLine().ToLower() != "quit")
                    goto EH3;*/

            /*EH2:
                try
                {
                    Calc ccex = new Calc();
                    ccex.Div();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                if (Console.ReadLine().ToLower() != "quit")
                    goto EH2;*/

            /*EH1:
                try
                {
                    Console.WriteLine("Enter numerator: ");
                    int num1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter denominator: ");
                    int num2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    int num3 = num1 / num2;
                    Console.WriteLine("Divison is " + num3);
                    Console.ReadLine();
                    Console.WriteLine();
                }
                catch (DivideByZeroException dbz) { Console.WriteLine("You tried to divide by zero, sorry we don't allow for that ;-;"); goto EH1; }
                catch (ArgumentException ae) {  Console.WriteLine("You entered an Invalid Number or Character or String.... Please do try again"); goto EH1; }
                catch (Exception ex) { Console.WriteLine("There was an error, sorry ;-;"); Console.WriteLine(ex.Message); }
                finally 
                { 
                    Console.WriteLine("An example of a valid operation would be :"); 
                    Console.WriteLine("Numerator - 10, Denominator - 5"); 
                    Console.WriteLine("Division is 2"); 
                }*/


            /*Student s1 = new Student();
            s1.Calculate();
            string gr;
            s1.getGrade(s1.Per, out gr);
            Console.WriteLine("Student's total marks is " + s1.Total);
            Console.WriteLine("Student's average percentage is " + s1.Per);
            Console.WriteLine("Student's grade is " + gr);
            Console.WriteLine();

            double pf, tax;
            s1.salarycalc(out pf,out tax);
            Console.WriteLine("Employee's Tax is " + tax);
            Console.WriteLine("Employee's PF is " + pf);*/

        END:
            Console.ReadLine();
        }
    }
}
