using Attributes;
using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;
using funge_98.Parsers;

namespace funge_98.Languages
{
    [ContainerElement]
    public class Trefunge : FungeFamilyLanguage
    {
        public Trefunge(CommandProducer commandProducer, TrefungeFileParser parser) : base(new TrefungeContext(commandProducer.FingerPrints),
            commandProducer, parser)
        {
        }
    }
}