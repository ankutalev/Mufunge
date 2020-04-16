using System.IO;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class PushCharacterCommand : Command
    {
        private readonly StreamReader _reader;

        public PushCharacterCommand(char name, StreamReader reader)
        {
            _reader = reader;
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.PushToStack(_reader.Read());
            return null;
        }
    }
}