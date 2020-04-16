namespace funge_98.Exceptions
{
    public class IncorrectFileFormatException : ParserException
    {
        public IncorrectFileFormatException(string message) : base(message)
        {
        }
    }
}