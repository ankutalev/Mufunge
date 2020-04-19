using System;
using System.IO;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands.IOCommands
{
    public abstract class AbstractInputCharacterCommand : ICommand
    {
        private readonly StreamReader _reader;

        protected AbstractInputCharacterCommand(StreamReader reader, char name)
        {
            _reader = reader;
            Name = name;
        }

        public char Name { get; }

        public string RealExecute(FungeContext fungeContext)
        {
            fungeContext.PushToTopStack(_reader.Read());
            return null;
        }
    }

    [ContainerElement, Unefunge]
    internal class ConsoleInputCharacterCommand : AbstractInputIntegerCommand
    {
        public ConsoleInputCharacterCommand() : base(new StreamReader(Console.OpenStandardInput()),'~')
        {
        }
    }
}