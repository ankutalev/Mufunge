using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.Commands;
using funge_98.FactoriesStuff.Factories;

namespace funge_98.FactoriesStuff
{
    [ContainerElement]
    public class CommandProducer
    {
        private readonly Dictionary<char, Command> _commandMap;

        public CommandProducer(Funge98CommandsFactory factory)
        {
            _commandMap = factory.CreateProducts().ToDictionary(c=>c.Name);
        }

        public Command GetCommand(int name)
        {
            return _commandMap[(char) name];
        }
    }
}