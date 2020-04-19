using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge93Commands;
using funge_98.FactoriesStuff.Factories;
using funge_98.FingerPrints;

namespace funge_98.FactoriesStuff
{
    [ContainerElement]
    public class CommandProducer
    {
        public List<IFingerPrint> FingerPrints { get; }
        private readonly Dictionary<char, Command> _commandMap;

        public CommandProducer(Funge98CommandsFactory factory, List<IFingerPrint> fingerPrints)
        {
            FingerPrints = fingerPrints;
            _commandMap = factory.CreateProducts().ToDictionary(c=>c.Name);
        }

        public Command GetCommand(int name)
        {
            try
            {
                return _commandMap[(char) name];
            }
            catch
            {
                return new PushHexNumberCommand((char)name);
            }
        }
        
    }
}