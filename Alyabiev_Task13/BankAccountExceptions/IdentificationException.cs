using System;

namespace BankAccountExceptions
{
    public class IdentificationException : Exception
    {
        public IdentificationException(string message) : base(message) { }
    }
}
