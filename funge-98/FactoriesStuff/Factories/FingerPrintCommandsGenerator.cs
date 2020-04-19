using System.Collections.Generic;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge98Commands;

namespace funge_98.FactoriesStuff.Factories
{
    [ContainerElement]
    public class FingerPrintCommandsGenerator : IFactory<ICommand>
    {
        public IEnumerable<ICommand> CreateProducts()
        {
            for (var i = 'A'; i < 'Z'; i++)
            {
                yield return new FingerPrintCommand(i);
            }
        }
    }
}