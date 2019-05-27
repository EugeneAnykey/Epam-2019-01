using System;

namespace BankAccountExceptions
{
    public class NameException : Exception
    {
        public NameException(string message) : base(message) { }
    }
}
