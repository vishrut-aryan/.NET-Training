using ExceptionExp;
using System;
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

    internal class Program
    {
        static void Main(string[] args)
        {
        EH3:
            bankacc ba = new bankacc();
            Console.WriteLine();
            Console.WriteLine("Wanna continue? y or n");
            if (Console.ReadLine().ToUpper() != "Y") { goto END; }
            goto EH3;

            /*EH2:
            try
            {
                Calc ccex = new Calc();
                ccex.Div();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); goto EH2; }
            //goto EH2;*/

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
