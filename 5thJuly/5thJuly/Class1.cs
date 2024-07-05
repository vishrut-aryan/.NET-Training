using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5thJuly
{
    internal class Employee
    {
        public int Id;
        public string EmpName;
        public double Salary;

        public void disconnDB(SqlConnection conn1)
        {
            SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM emp1", conn1);
            DataTable dt = new DataTable();
            adap.Fill(dt);  //  Opens the connection, Grabs the data, Auto closes the connection

            foreach (DataRow dr in dt.Rows)
            {
                Console.Write(dr[0].ToString() + " ");
                Console.Write(dr[1].ToString() + " ");
                Console.Write(dr[2].ToString() + " ");
                Console.WriteLine("");
            }
            Console.WriteLine("\n");
        }

        public void connDB(SqlConnection conn1)
        {
            List<Employee> emplist = new List<Employee>();
            SqlDataReader adr = null;
            conn1.Open();  //  We open the connection

            SqlCommand cmd = new SqlCommand("SELECT * FROM emp1", conn1);
            adr = cmd.ExecuteReader();

            while (adr.Read())  //  We grab the data
            {
                Employee e1 = new Employee();
                e1.Id = Convert.ToInt32(adr[0]);
                e1.EmpName = adr[1].ToString();
                e1.Salary = Convert.ToDouble(adr[2]);
                emplist.Add(e1);
            }
            conn1.Close();  //  We close the connection

            foreach (Employee e in emplist)
            {
                Console.Write(e.Id + " ");
                Console.Write(e.EmpName + " ");
                Console.Write(e.Salary + " ");
                Console.WriteLine("");
            }
            Console.WriteLine("\n");

        }
    }
}
