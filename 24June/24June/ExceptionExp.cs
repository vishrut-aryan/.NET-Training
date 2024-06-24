using System;
using System.Collections.Generic;
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
        private string _accname;
        private double _balance;

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
            }
            catch (Exception ex) { Console.WriteLine((ex.Message)); }
        }
    }
}
