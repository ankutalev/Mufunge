using System;
using System.IO;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands.IOCommands
{
    public abstract class AbstractOutputAsAsciiCommand : ICommand
    {
        private readonly StreamWriter _writer;

        protected AbstractOutputAsAsciiCommand(StreamWriter writer)
        {
            _writer = writer;
            _writer.AutoFlush = true;
        }

        public char Name { get; } = ',';

        public string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(1);
            _writer.Write((char) values[0]);
            return null;
        }
    }

    [ContainerElement, Unefunge]
    internal class ConsoleOutputAsAsciiCommand : AbstractOutputAsAsciiCommand
    {
        public ConsoleOutputAsAsciiCommand() : base(new StreamWriter(Console.OpenStandardOutput()))
        {
        }
    }
}