using System;

namespace P07_CustomException
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {
        }

        public InvalidPersonNameException(string message) 
            : base(message)
        {
        }
    }
}
