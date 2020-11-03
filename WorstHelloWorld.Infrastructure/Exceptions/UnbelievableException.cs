using System;

namespace WorstHelloWorld.Infrastructure.Exceptions
{
    class UnbelievableException : Exception
    {
        public UnbelievableException()
            : base("This is Unbelievable")
        {
        }

        public UnbelievableException(string message)
            : base("This is Unbelievable")
        {
        }

        public UnbelievableException(string message, Exception inner)
            : base("This is Unbelievable", inner)
        {
        }
    }
}
