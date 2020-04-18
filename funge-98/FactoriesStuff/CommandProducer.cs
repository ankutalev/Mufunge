using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.Commands;

namespace funge_98.FactoriesStuff
{
    [ContainerElement]
    public class CommandProducer
    {
        private readonly Dictionary<char, Command> _commandMap;

        public CommandProducer(List<IFactory<Command>> factories)
        {
            IEnumerable<Command> allCommands = new List<Command>();
            _commandMap = factories
                .Aggregate(allCommands, (current, factory) => current.Concat(factory.CreateProducts()))
                .ToDictionary(c => c.Name);
        }

        public Command GetCommand(char name)
        {
            return _commandMap[name];
        }
    }
}