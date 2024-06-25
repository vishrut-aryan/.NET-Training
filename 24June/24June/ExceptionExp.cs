using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionExp
{
    public class BusinessException:Exception
    {
        public int ErrorCode;
        public string ErrorMsg;

        public BusinessException() { }

        public BusinessException(string errorMsg):base(errorMsg)
        {
            ErrorMsg = errorMsg;
        }
    }

    public class bankacc
    {
        private int _accno;
        public string _accname;
        public double _balance;

        public bankacc()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Enter Acc No: ");
                _accno = Convert.ToInt32(Console.ReadLine());
                if (_accno <= 0) { throw new BusinessException("Account No. is not valid"); }
                Console.WriteLine();

                Console.WriteLine("Enter Acc Name: ");
                _accname = Console.ReadLine();
                for (int i = 0; i <= 9; i++)
                    if (_accname.Contains(i.ToString())) { throw new BusinessException("Account Name should not contain numbers"); }
                Console.WriteLine();

                Console.WriteLine("Enter Balance: ");
                _balance = Convert.ToDouble(Console.ReadLine());
                if (_balance <= 0) { throw new BusinessException("Balance Amount is not valid"); }
                Console.WriteLine();

                Console.WriteLine("Account Recorded");
                Console.WriteLine();
            }
            catch (Exception ex) 
            {
                Console.WriteLine();
                Console.WriteLine();

                string fileName = "ErrorLog.txt";
                string priorText = File.ReadAllText(fileName);

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    Console.Write((" || " + System.DateTime.Now.ToString()) + " || ");
                    Console.WriteLine();
                    Console.WriteLine(("    Error Message:   " + ex.Message));
                    Console.WriteLine();
                    Console.WriteLine(("    Error Type:      " + ex.GetType()));
                    Console.WriteLine();
                    Console.WriteLine(("    Source:          " + ex.Source));
                    Console.WriteLine();
                    Console.WriteLine(("    Stack Trace:  " + ex.StackTrace));
                    Console.WriteLine();
                    Console.WriteLine(("    Target Site:     " + ex.TargetSite));
                    Console.WriteLine();
                    Console.WriteLine(("    Inner Exception: " + ex.InnerException));
                    Console.WriteLine();
                    Console.WriteLine();
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

                Console.WriteLine(finalReadText);
            }
        }
    }
}
