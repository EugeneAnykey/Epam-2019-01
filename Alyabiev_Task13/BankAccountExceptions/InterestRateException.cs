using System;

namespace BankAccountExceptions
{
    public class InterestRateException : Exception
    {
        public InterestRateException(string message) : base(message) { }
    }
}
