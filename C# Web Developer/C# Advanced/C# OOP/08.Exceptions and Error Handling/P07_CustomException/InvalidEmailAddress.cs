namespace P07_CustomException
{
    using System;

    public class InvalidEmailAddress : Exception
    {
        public InvalidEmailAddress()
        {
        }

        public InvalidEmailAddress(string message) 
            : base(message)
        {
        }
    }
}
