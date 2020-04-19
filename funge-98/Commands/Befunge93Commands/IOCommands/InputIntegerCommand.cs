using System;
using System.IO;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands.IOCommands
{
    public abstract class AbstractInputIntegerCommand : ICommand
    {
        private readonly StreamReader _reader;

        protected AbstractInputIntegerCommand(StreamReader reader, char name)
        {
            _reader = reader;
            Name = name;
        }

        public char Name { get; }

        public string RealExecute(FungeContext fungeContext)
        {
            if (!int.TryParse(_reader.ReadLine(), out var value))
            {
                return "Can't parse Integer from user input!";
            }

            fungeContext.PushToTopStack(value);
            return null;
        }
    }

    [ContainerElement, Unefunge]
    internal class InputIntegerCommand : AbstractInputIntegerCommand
    {
        public InputIntegerCommand() : base(new StreamReader(Console.OpenStandardInput()),'&')
        {
        }
    }
}