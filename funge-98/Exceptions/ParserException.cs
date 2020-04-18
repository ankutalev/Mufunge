using System;

namespace funge_98.Exceptions
{
    public abstract class ParserException : Exception
    {
        protected ParserException(string message) : base(message){}
    }
}