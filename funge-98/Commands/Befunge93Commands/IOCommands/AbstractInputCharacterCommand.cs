using System;
using System.IO;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands.IOCommands
{
    public abstract class AbstractInputCharacterCommand : ICommand
    {
        private readonly StreamReader _reader;

        protected AbstractInputCharacterCommand(StreamReader reader)
        {
            _reader = reader;
        }

        public char Name { get; } = '~';

        public string RealExecute(FungeContext fungeContext)
        {
            fungeContext.PushToTopStack(_reader.Read());
            return null;
        }
    }

    [ContainerElement, UnefungeCommand]
    internal class ConsoleInputCharacterCommand : AbstractInputIntegerCommand
    {
        public ConsoleInputCharacterCommand() : base(new StreamReader(Console.OpenStandardOutput()))
        {
        }
    }
}