using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;
using IronPdf;
using System.Xml.Serialization;

namespace _19June
{
    public class EmployeeDetails
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public double Tax { get; set; }
        public double PF { get; set; }
    }

    internal class Program
    {
        static int add(int x, int y)
        {
            return x + y;
        }

        static void mult(int x, int y)
        {
            x *= y;
            Console.WriteLine("Answer is " + x);
        }

        static double tax_calc(int salary)
        {
            double tax = 0;

            if (salary > 10)
            { tax = 0.3F; }

            else if (salary > 5)
            { tax = 0.2F; }

            else if (salary > 2.5)
            { tax = 0.1F; }

            return salary * (1 - tax);
        }

        static void Main(string[] args) 
        {
            //save text, save excel, save xml, save pdf
            char y = 'Y';
            do
            {
                Console.WriteLine("Enter the Employee ID: ");
                string emp_id = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Enter the Employee Name: ");
                string emp_name = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Enter the Employee Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());
                string salary_str = Convert.ToString(salary);
                Console.WriteLine();

                double tax = tax_calc(salary);
                string tax_str = Convert.ToString(tax);
                double pf = 0.12 * salary;
                string pf_str = Convert.ToString(pf);

                var html_input = $@"
                    <h1>Employee Details</h1>
                    <p><strong>Employee ID:</strong> {emp_id}</p>
                    <p><strong>Employee Name:</strong> {emp_name}</p>
                    <p><strong>Employee Salary:</strong> {salary}</p>
                    <p><strong>Tax:</strong> {tax_str}</p>
                    <p><strong>PF:</strong> {pf_str}</p>
                ";

                var Renderer = new IronPdf.ChromePdfRenderer();
                using (PdfDocument Pdf = Renderer.RenderHtmlAsPdf(html_input))
                {
                    Pdf.SaveAs("employee_details.pdf");
                }
            }
            while (y == 'Y');





            /*char y = 'Y';
            List<EmployeeDetails> employees = new List<EmployeeDetails>();
            do
            {
                Console.WriteLine("Enter the Employee ID: ");
                string emp_id = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Enter the Employee Name: ");
                string emp_name = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Enter the Employee Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                double tax = tax_calc(salary);
                double pf = 0.12 * salary;

                EmployeeDetails emp = new EmployeeDetails
                {
                    EmployeeID = emp_id,
                    EmployeeName = emp_name,
                    Salary = salary,
                    Tax = tax,
                    PF = pf
                };
                employees.Add(emp);

                Console.WriteLine("Would you like to record another Employee? Enter Y if yes");
                y = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.WriteLine();
            } 
            while (y == 'Y');

            string fileName = "Employee Details.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<EmployeeDetails>));
            using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            {
                serializer.Serialize(fs, employees);
            }*/



            /*int unicode = 65;
            int emp_no = 3;
            char y = 'Y';
            do
            {
                Console.WriteLine("Enter the Employee ID: ");
                string emp_id = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Enter the Employee Name: ");
                string emp_name = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Enter the Employee Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                double tax = tax_calc(salary);
                double pf = 0.12 * salary;

                string[] details = { emp_id, emp_name, Convert.ToString(salary), Convert.ToString(tax), Convert.ToString(pf) };

                String range = "A" + emp_no + ":E" + emp_no;
                WorkBook workBook = WorkBook.Load("Employee Details.xlsx");
                WorkSheet workSheet = workBook.DefaultWorkSheet;

                Range cellRange = workSheet[range];

                // iterate over range of cells
                int columnIndex = unicode;
                foreach (var cell in cellRange)
                {
                    if (columnIndex - unicode < details.Length)
                    {
                        string cellName = $"{(char)columnIndex}{cell.RowIndex}";
                        workSheet[cellName].Value = details[columnIndex - unicode];
                        Console.WriteLine("Cell {0} now has value '{1}'", cellName, workSheet[cellName].Value);
                    }
                    else
                    {
                        // Handle the case where columnIndex is out of bounds of details array
                        Console.WriteLine("Error: ColumnIndex exceeds details array length.");
                        break;
                    }
                    columnIndex++;
                }
                workBook.Save();

                Console.WriteLine("Would you like to record another Employee? Enter Y if yes");
                y = Convert.ToChar(Console.ReadLine().ToUpper());
                emp_no++;
                Console.WriteLine();
            } while (y == 'Y');*/



            /*string fileName = "Employee Details.txt";
            string priorText = File.ReadAllText(fileName);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                char y = 'Y';
                do
                {
                    Console.WriteLine("Enter the Employee ID: ");
                    string emp_id = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Enter the Employee Name: ");
                    string emp_name = Console.ReadLine();
                    Console.WriteLine();

                    Console.WriteLine("Enter the Employee Salary: ");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    double tax = tax_calc(salary);
                    double pf = 0.12 * salary;

                    writer.WriteLine("Employee ID:     " + emp_id);
                    writer.WriteLine("Employee Name:   " + emp_name);
                    writer.WriteLine("Employee Salary: " + salary);
                    writer.WriteLine("Employee Tax:    " + tax);
                    writer.WriteLine("Employee PF:     " + pf);
                    writer.WriteLine("");

                    Console.WriteLine("Would you like to record another Employee? Enter Y if yes");
                    y = Convert.ToChar(Console.ReadLine().ToUpper());
                    Console.WriteLine();
                } while (y == 'Y');
            }

            string readText = File.ReadAllText(fileName);
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                Console.WriteLine("Would you like to clear the file before writing? Enter Y if yes");
                if ("Y" != Console.ReadLine().ToUpper())
                {
                    writer.WriteLine(priorText);
                }
                writer.WriteLine(readText);
            }

            string finalReadText = File.ReadAllText(fileName);
            Console.WriteLine(finalReadText);*/





            /*int t = add(10, 20);
            Console.WriteLine("10 + 20 = " + t);
            mult(15, 16);
            Console.WriteLine();

            char y = 'Y';
            do
            {
                Console.WriteLine("Enter salary in Lakhs: ");
                int salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Your taxed salary is: " + tax_calc(salary) + " Lakhs");
                Console.WriteLine();
                Console.WriteLine("Would you like to calculate another salary amount? Enter Y if yes");
                y = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.WriteLine();
            } while (y == 'Y');*/





            /*char y = 'Y';
            do
            {
                float tax = 0;
                do
                {
                    Console.WriteLine("Enter salary in Lakhs(Enter 0 to exit): ");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if (salary > 10)
                    {
                        tax = 0.3F;
                        Console.WriteLine("Your taxed salary is: " + (salary * (1 - tax)) + " Lakhs");
                    }

                    else if (salary > 5)
                    {
                        tax = 0.2F;
                        Console.WriteLine("Your taxed salary is: " + (salary * (1 - tax)) + " Lakhs");
                    }

                    else if (salary > 2.5)
                    {
                        tax = 0.1F;
                        Console.WriteLine("Your taxed salary is: " + (salary * (1 - tax)) + " Lakhs");
                    }

                    else
                    {
                        Console.WriteLine("Invalid Salary Amount");
                    }
                } 
                while (tax != 0F);

                Console.WriteLine("Would you like to record another salary amount? Enter Y if yes, and N if no");
                y = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.WriteLine();
            }
            while (y == 'Y');*/





            /*string name;
            //int eng, sci, math;
            string[] subjects = {"eng", "sci", "math"};
            int[] marks = {0, 0, 0};

            char y = 'Y';
            //while (y == 'Y')
            do
            {
                int len = subjects.Length;

                Console.WriteLine("Enter student's name: ");
                name = Console.ReadLine();
                Console.WriteLine();

                while (len > 0)
                {
                    Console.WriteLine("Enter " + name + "'s " + subjects[len - 1] + " Marks: ");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    marks.SetValue(mark, (len - 1));
                    len--;
                }

                int total = marks[0] + marks[1] + marks[2];
                int avg = total/3;

                if (marks[0] == 0 && marks[1] == 0 && marks[2] == 0)
                {
                    Console.WriteLine("Marks are not valid!");
                    Console.WriteLine("Try Again");
                    Console.WriteLine();
                    continue;
                }

                else if (avg >= 90)
                {
                    Console.WriteLine("Distinction");
                    Console.WriteLine(name + "'s total marks: " + total);
                    Console.WriteLine(name + "'s percentage: " + avg);
                    Console.WriteLine();
                }

                else if (avg >= 70)
                {
                    Console.WriteLine("Above Average");
                    Console.WriteLine(name + "'s total marks: " + total);
                    Console.WriteLine(name + "'s percentage: " + avg);
                    Console.WriteLine();
                }

                else if (avg > 40)
                {
                    Console.WriteLine("Pass");
                    Console.WriteLine(name + "'s total marks: " + total);
                    Console.WriteLine(name + "'s percentage: " + avg);
                    Console.WriteLine();
                }

                else if (avg <= 40)
                {
                    Console.WriteLine("Fail");
                    Console.WriteLine(name + "'s total marks: " + total);
                    Console.WriteLine(name + "'s percentage: " + avg);
                    Console.WriteLine();
                }

                //Console.WriteLine("Enter student's English Marks: ");
                //eng = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Enter student's Science Marks: ");
                //sci = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Enter student's Math Marks: ");
                //math = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine();

                Console.WriteLine("Would you like to record another student? Enter Y if yes, and N if no");
                y = Convert.ToChar(Console.ReadLine().ToUpper());
                Console.WriteLine();
            } 
            while (y == 'Y');*/






            /*int n;

            Console.WriteLine("Enter a number: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i < (n + 1); i++)
            {
                for (int j = 1; j < (i + 1); j++)
                {
                    Console.Write(i);
                }

                for (int j = (n - i + 1); j > 0; j--)
                {
                    Console.Write(n - (i - 1));
                }

                Console.WriteLine();
            }*/

            Console.ReadLine();
        }
    }
}
