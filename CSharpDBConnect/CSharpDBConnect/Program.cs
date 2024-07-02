using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CSharpDBConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // SqlConnection scoon = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;Integrated Security = true");
            // Integrated Security: Windows Auth

            SqlConnection scoon = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = HOLTEC;User Id = sa;Password = 12345");
            // User Id & Password: SQL Server Auth

            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter English Marks: ");
            double engmarks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Science Marks: ");
            double scnmarks = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Maths Marks: ");
            double mathmarks = Convert.ToDouble(Console.ReadLine());

            string query = "INSERT INTO STUDENT VALUES('" + name + "', " + engmarks + ", " + scnmarks + ", " + mathmarks + ")";

            SqlCommand cmd = new SqlCommand(query, scoon);
            scoon.Open();
            cmd.ExecuteNonQuery();
            scoon.Close();

            Console.WriteLine("Code Executed");
            Console.ReadLine();
        }
    }
}
