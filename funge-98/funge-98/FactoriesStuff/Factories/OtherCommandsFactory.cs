using System.Collections.Generic;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge93Commands;

namespace funge_98.FactoriesStuff.Factories
{
    [ContainerElement]
    public class OtherCommandsFactory : IFactory<Command>
    {
        public IEnumerable<Command> CreateProducts()
        {
            return new List<Command>
            {
                new VerticalIfCommand('|'),
                new ToggleStringModeCommand('"'),
                new VerticalIfCommand('|'),
                new KillThreadCommand('@'),
                new PutCommand('p'),
                new GetCommand('g'),
                new BridgeCommand('#'),
                new DiscardCommand('$'),
                new DuplicateCommand(':'),
                new HorizontalIfCommand('_'),
                new GreaterThanCommand('`'),
                new LogicalNotCommand('!'),
            };
        }
    }
}