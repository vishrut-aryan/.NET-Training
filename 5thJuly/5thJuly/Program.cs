using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _5thJuly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn1 = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS; Initial Catalog = AdventureWorksDW2016; User Id = sa; Password = 12345; ");
            
            //  Disconnected DB Architechture
            /*SqlDataAdapter adap = new SqlDataAdapter("SELECT * FROM emp1", conn1);
            DataTable dt = new DataTable();
            adap.Fill(dt);  //  Opens the connection, Grabs the data, Auto closes the connection

            foreach (DataRow dr in dt.Rows)
            {
                Console.Write(dr[0].ToString() + " ");
                Console.Write(dr[1].ToString() + " ");
                Console.Write(dr[2].ToString() + " ");
                Console.WriteLine();
            }*/

            //  Connected DB Architechture
            SqlDataReader adr = null;
            conn1.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM emp1", conn1);
            adr = cmd.ExecuteReader();

            while (adr.Read())
            {
                Console.WriteLine(adr[0].ToString());
                Console.WriteLine(adr[1].ToString());
                Console.WriteLine(adr[2].ToString());
            }
            conn1.Close();

            Console.ReadLine();
        }
    }
}
