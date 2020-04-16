using System.IO;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class PushIntegerCommand : Command
    {
        private readonly StreamReader _reader;

        public PushIntegerCommand(char name, StreamReader reader)
        {
            _reader = reader;
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            if (!int.TryParse(_reader.ReadLine(), out var value))
            {
                return "Can't parse Integer from user input!";
            }
            fungeContext.PushToStack(value);
            return null;
        }
    }
}