using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountExceptions
{
    public class DepositException : Exception
    {
        public DepositException(string message) : base(message) { }

        public DepositException(string message, decimal ammount) : base(string.Format(message, ammount)) { }
    }
}
