using System;
using System.IO;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands.IOCommands
{
    public abstract class AbstractOutputAsIntegerCommand : ICommand
    {
        private readonly StreamWriter _writer;

        protected AbstractOutputAsIntegerCommand(StreamWriter writer)
        {
            _writer = writer;
        }

        public char Name { get; } = '.';

        public string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(1);
            _writer.Write(values[0]);
            return null;
        }
    }

    [ContainerElement, UnefungeCommand]
    internal class ConsoleOutputAsIntegerCommand : AbstractOutputAsIntegerCommand
    {
        public ConsoleOutputAsIntegerCommand() : base(new StreamWriter(Console.OpenStandardOutput()))
        {
        }
    }
}