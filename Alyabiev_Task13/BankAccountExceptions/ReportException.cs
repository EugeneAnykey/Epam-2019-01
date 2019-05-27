using System;

namespace BankAccountExceptions
{
    public class ReportException : Exception
    {
        public ReportException(string message) : base(message) { }
    }
}
