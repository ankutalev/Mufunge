using System.IO;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class InputCharacterCommand : Command
    {
        private readonly StreamReader _reader;

        public InputCharacterCommand(StreamReader reader)
        {
            _reader = reader;
        }

        public override char Name { get; } = '~';

        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.PushToTopStack(_reader.Read());
            return null;
        }
    }
}