using System;

namespace BankAccountExceptions
{
    public class AccountException : Exception
    {
        public AccountException(string message) : base(message) { }
    }
}
