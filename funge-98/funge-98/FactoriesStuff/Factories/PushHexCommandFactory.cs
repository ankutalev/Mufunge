using System.Collections.Generic;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge93Commands;

namespace funge_98.FactoriesStuff.Factories
{
    [ContainerElement]
    public class PushHexCommandFactory : IFactory<Command>
    {
        public IEnumerable<Command> CreateProducts()
        {
            //kakoy bagor))))
            var chars = new[]{'0','1','2','3','4','5','6','7','8','9', 'a', 'b', 'c', 'd', 'e', 'f'};
            foreach (var c in chars)
            {
                yield return new PushHexNumberCommand(c);
            }
        }
    }
}