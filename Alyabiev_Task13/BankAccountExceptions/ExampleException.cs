using System;

namespace BankAccountExceptions
{
    public class ExampleException : Exception
    {
        public ExampleException(string message) : base(message) { }
    }
}
