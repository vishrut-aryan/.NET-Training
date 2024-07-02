using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CSharpDBConnect
{
    public class Student 
    {
        public int rollno;
        public string name;
        public double engmarks;
        public double scnmarks;
        public double mathmarks;

        SqlConnection scoon = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345");

        public void Printing(DataTable dt)
        {
            string row0 = String.Format("\n| {0, -6} | {1, -25} | {2, -8} | {3, -8} | {4, -9} | {5, -10} | {6, -7} | ", "ROLLNO", "STUDENTNAME", "ENGMARKS", "SCNMARKS", "MATHMARKS", "TOTALMARKS", "PER");
            Console.WriteLine(row0);
            foreach (DataRow dr in dt.Rows)
            {
                string row1 = String.Format("| {0, -6} | ", dr[0]);
                Console.Write(row1);
                string row2 = String.Format("{0, -25} | ", dr[1]);
                Console.Write(row2);
                string row3 = String.Format("{0, -8} | ", dr[2]);
                Console.Write(row3);
                string row4 = String.Format("{0, -8} | ", dr[3]);
                Console.Write(row4);
                string row5 = String.Format("{0, -9} | ", dr[4]);
                Console.Write(row5);
                string row6 = String.Format("{0, -10} | ", dr[5]);
                Console.Write(row6);
                string row7 = String.Format("{0, -7:C2} | ", dr[6]);
                Console.Write(row7);
                Console.WriteLine();
            }
        }

        public void GetStudent()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM STUDENT", scoon);
            adap.Fill(dt);  //  Takes data, dumps into an object
            Printing(dt);
        }

        public void DeleteStudent()
        {
            string query = "DELETE FROM STUDENT WHERE STUDENTNAME = '" + name + "'";
            SqlCommand cmd = new SqlCommand(query, scoon);
            scoon.Open();
            cmd.ExecuteNonQuery();
            scoon.Close();
            Console.WriteLine("\nStudent Deleted");
            Console.ReadLine();
        }

        public void AddStudent()
        {
            Console.WriteLine("\nEnter English Marks: ");
            engmarks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nEnter Science Marks: ");
            scnmarks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nEnter Maths Marks: ");
            mathmarks = Convert.ToDouble(Console.ReadLine());

            string query = "INSERT INTO STUDENT VALUES('" + name + "', " + engmarks + ", " + scnmarks + ", " + mathmarks + ")";
            // string query = "EXEC sp_addstudent '" + name + "', " + engmarks + ", " + scnmarks + ", " + mathmarks + ";
            SqlCommand cmd = new SqlCommand(query, scoon);

            scoon.Open();
            cmd.ExecuteNonQuery();  // Returns number of columns affected
            // cmd.ExecuteScalar();    Returns a single value
            scoon.Close();
            
            Console.WriteLine("\nStudent Added");
            Console.ReadLine();
        }

        public void AddingStudentParameter()
        {
            Console.WriteLine("\nEnter English Marks: ");
            engmarks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nEnter Science Marks: ");
            scnmarks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nEnter Maths Marks: ");
            mathmarks = Convert.ToDouble(Console.ReadLine());

            // Standard Structured Method used for calling Stored Procedures from C#
            SqlCommand cmd = new SqlCommand("sp_addstudent", scoon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@eng", engmarks);
            cmd.Parameters.AddWithValue("@scn", scnmarks);
            cmd.Parameters.AddWithValue("@math", mathmarks);

            scoon.Open();
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            Printing(dt);
            scoon.Close();

            Console.WriteLine("\nStudent Added");
            Console.ReadLine();
        }

        public void GetStudentName()
        {
            Console.WriteLine("\nEnter Name: ");
            name = Console.ReadLine();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                REDO:
                Student s1 = new Student();
                s1.GetStudentName();

                Console.WriteLine("\nWould you like to view, add or delete a record, enter (0) or (1) or (2) or maybe a mysterious (3)....");
                string c1 = Console.ReadLine();
                if (c1 == "0")
                    s1.GetStudent();
                else if (c1 == "1")
                    s1.AddStudent();
                else if (c1 == "2")
                    s1.DeleteStudent();
                else if (c1 == "3")
                    s1.AddingStudentParameter();

                Console.WriteLine("\nDo you want to do more operations? Enter Y if yes");
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "Y")
                    goto REDO;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("\nWe have an Error! Yayyyyyyyyyyyyyyyyyyyyyy...................\n"); 
                Console.WriteLine(ex.Message);
                Console.ReadLine(); 
            }
            Console.WriteLine("\nCode Executed");
        }
    }
}
