using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5thJuly2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SqlConnection coon2 = new SqlConnection("Data Source = HA-NB69\\SQLEXPRESS;Initial Catalog = AdventureWorksDW2016;User Id = sa;Password = 12345;");
            SqlTransaction tran1;

            coon2.Open();
            tran1 = coon2.BeginTransaction();

            try
            {
                SqlCommand comm1 = new SqlCommand("INSERT INTO CUSTOMER VALUES (1, 'AMIT', 'PUNE')", coon2, tran1);
                SqlCommand comm2 = new SqlCommand("INSERT INTO CUSTOMER VALUES (2, 'SUNIL', 'PUNE')", coon2, tran1);
                SqlCommand comm3 = new SqlCommand("INSERT INTO CUSTOMER VALUES (1, 'KAPIL', 'PUNE')", coon2, tran1);
                SqlCommand comm4 = new SqlCommand("INSERT INTO CUSTOMER VALUES (4, 'RANJIT', 'PUNE')", coon2, tran1);

                comm1.ExecuteNonQuery();
                comm2.ExecuteNonQuery();
                comm3.ExecuteNonQuery();
                comm4.ExecuteNonQuery();

                tran1.Commit();
                Console.WriteLine("Transactions Commited");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                try
                {
                    tran1.Rollback();
                }
                catch ( Exception ex1) {  Console.WriteLine(ex1.Message); }
            }
            coon2.Close();

            Console.ReadLine();
        }
    }
}
