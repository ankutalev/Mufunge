using System.Collections.Generic;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge93Commands;

namespace funge_98.FactoriesStuff.Factories
{
    [ContainerElement]
    public class ArithmeticCommandFactory : IFactory<Command>
    {
        public IEnumerable<Command> CreateProducts()
        {
            return new List<Command>
            {
                new ArithmeticCommand((x, y) => x + y, '+'),
                new ArithmeticCommand((x, y) => x * y, '*'),
                new ArithmeticCommand((x, y) => x - y, '-'),
                new ArithmeticCommand((x, y) => x / y, '/'),
                new ArithmeticCommand((x, y) => x % y, '%'),
            };
        }
    }
}