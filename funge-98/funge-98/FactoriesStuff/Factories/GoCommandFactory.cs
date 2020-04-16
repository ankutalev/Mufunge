using System.Collections.Generic;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge93Commands;

namespace funge_98.FactoriesStuff.Factories
{
    [ContainerElement]
    public class GoCommandFactory : IFactory<Command>
    {
        public IEnumerable<Command> CreateProducts()
        {
            return new List<Command>
            {
                new GoCommand('<'),
                new GoCommand('v'),
                new GoCommand('^'),
                new GoCommand('>'),
                new GoCommand('?')
            };
        }
    }
}