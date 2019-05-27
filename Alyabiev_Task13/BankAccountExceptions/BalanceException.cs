using System;

namespace BankAccountExceptions
{
    public class BalanceException : Exception
    {
        public BalanceException(string message) : base(message) { }
    }
}
