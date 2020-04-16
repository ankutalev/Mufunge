using System.IO;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class OutputAsIntegerCommand : Command
    {
        private readonly StreamWriter _writer;

        public OutputAsIntegerCommand(char name, StreamWriter writer)
        {
            _writer = writer;
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            if (fungeContext.GetStackTopValues(1, out var values))
            {
                return "Stack empty!";
            }
            _writer.Write(values[0]);
            return null;
        }
    }
}