using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge98Commands;
using funge_98.FactoriesStuff.Factories;
using funge_98.FingerPrints;

namespace funge_98.FactoriesStuff
{
    [ContainerElement]
    public class CommandProducer
    {
        public List<IFingerPrint> FingerPrints { get; }
        private readonly Dictionary<char, ICommand> _commandMap;

        public CommandProducer(List<ICommand> commands, List<IFingerPrint> fingerPrints, List<IFactory<ICommand>> generators)
        {
            FingerPrints = fingerPrints;
            commands = generators.Aggregate(commands, (current, generator) => current.Concat(generator.CreateProducts()).ToList());
            commands.Add(new IterateCommand(commands));
            _commandMap = commands.ToDictionary(c=>c.Name);
        }

        public ICommand GetCommand(int name)
        {
            //todo wtf try?
            try
            {
                return _commandMap[(char) name];
            }
            catch
            {
                return new PushHexNumberCommand((char) name);
            }
        }
        
    }
}