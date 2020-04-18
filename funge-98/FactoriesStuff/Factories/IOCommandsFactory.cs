using System;
using System.Collections.Generic;
using System.IO;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge93Commands;

namespace funge_98.FactoriesStuff.Factories
{
    [ContainerElement]
    public class IOCommandsFactory : IFactory<Command>
    {
        public IEnumerable<Command> CreateProducts()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true};
            var sr = new StreamReader(Console.OpenStandardInput());
            return new List<Command>
            {
                new OutputAsAsciiCommand(sw),
                new OutputAsIntegerCommand(sw),
                new InputCharacterCommand(sr),
                new InputIntegerCommand(sr),
            };
        }
    }
}