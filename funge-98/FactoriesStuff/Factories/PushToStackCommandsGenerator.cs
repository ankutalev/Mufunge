using System.Collections.Generic;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge93Commands;
using funge_98.Commands.Befunge98Commands;

namespace funge_98.FactoriesStuff.Factories
{
    [ContainerElement]
    public class PushToStackCommandsGenerator : IFactory<ICommand>
    {
        public IEnumerable<ICommand> CreateProducts()
        {
            for (var i = '0'; i <= '9'; i++)
            {
                yield return new PushDecimalNumberCommand(i);
            }

            for (var i = 'a'; i <= 'f'; i++)
            {
                yield return new PushHexNumberCommand(i);
            }
        }
    }
}