using Attributes;
using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;
using funge_98.Parsers;

namespace funge_98.Languages
{
    [ContainerElement]
    public class Befunge93 : FungeFamilyLanguage
    {
        public Befunge93(CommandProducer commandProducer, Befunge93FileParser parser) : base(new Befunge93Context(),
            commandProducer, parser)
        {
        }
    }
}