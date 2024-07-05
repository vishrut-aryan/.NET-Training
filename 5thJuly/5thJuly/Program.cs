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
            SqlConnection conn1 = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS; Initial Catalog = AdventureWorksDW2016; User Id = sa; Password = 12345;");
            
            Employee emp = new Employee();

            //  Disconnected DB Architechture
            emp.disconnDB(conn1);

            //  Connected DB Architechture
            emp.connDB(conn1);

            Console.ReadLine();
        }
    }
}
