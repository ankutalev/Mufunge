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
            //todo are set methods required?
            var sw = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true};
            Console.SetOut(sw);
            var sr = new StreamReader(Console.OpenStandardInput());
            Console.SetIn(sr);
            return new List<Command>
            {
                new OutputAsAsciiCommand(',',sw),
                new OutputAsIntegerCommand('.',sw),
                new InputCharacterCommand('~',sr),
                new InputIntegerCommand('&',sr),
            };
        }
    }
}