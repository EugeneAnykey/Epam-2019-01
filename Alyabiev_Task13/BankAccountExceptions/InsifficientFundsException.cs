using System;

namespace BankAccountExceptions
{
    public class InsifficientFundsException : Exception
    {
        public InsifficientFundsException() : base("Insifficient amount of funds") { }

        public InsifficientFundsException(string message) : base(message) { }
    }
}
