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

    public delegate void dlg(Exception ex);

    public class bankacc
    {
        private int _accno;
        public string _accname;
        public double _balance;

        public void print_error(Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine();
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

            Console.WriteLine("Error Printed");
        }

        public void log_error(Exception ex)
        {
            FileStream fs = new FileStream(@"ErrorLog.pdf", FileMode.Append);
            StreamWriter str = new StreamWriter(fs);

            str.Write((" || " + System.DateTime.Now.ToString()) + " || ");
            str.WriteLine();
            str.WriteLine(("    Error Message:   " + ex.Message));
            str.WriteLine();
            str.WriteLine(("    Error Type:      " + ex.GetType()));
            str.WriteLine();
            str.WriteLine(("    Source:          " + ex.Source));
            str.WriteLine();
            str.WriteLine(("    Stack Trace:  " + ex.StackTrace));
            str.WriteLine();
            str.WriteLine(("    Target Site:     " + ex.TargetSite));
            str.WriteLine();
            str.WriteLine(("    Inner Exception: " + ex.InnerException));
            str.WriteLine();
            str.WriteLine();

            str.Close();
            fs.Close();

            Console.WriteLine("Error Logged");
        }

        public void error_logging(dlg d, Exception ex)
        {
            d(ex);
        }

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
                dlg d = new dlg(log_error);
                d += new dlg(print_error);
                error_logging(d, ex);
            }
        }
    }
}
