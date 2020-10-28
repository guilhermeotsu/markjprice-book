using System;

namespace PacktLibrary
{
    public class PersonException : Exception
    {
        public PersonException() : base() { }

        public PersonException(string message, Exception innerException) : base(message, innerException) { }
    }
}