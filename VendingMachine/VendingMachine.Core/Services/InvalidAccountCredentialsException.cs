using System;

namespace VendingMachine.Core.Services
{
    public class InvalidAccountCredentialsException : Exception
    {
        public InvalidAccountCredentialsException() : base()
        {

        }

        public InvalidAccountCredentialsException(string message) : base(message)
        {

        }
    }
}
