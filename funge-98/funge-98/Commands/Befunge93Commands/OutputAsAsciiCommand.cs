using System.IO;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class OutputAsAsciiCommand : Command
    {
        private readonly StreamWriter _writer;

        public OutputAsAsciiCommand(char name, StreamWriter writer)
        {
            _writer = writer;
            Name = name;
        }

        public override char Name { get; }

        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(1);
            _writer.Write((char) values[0]);
            return null;
        }
    }
}