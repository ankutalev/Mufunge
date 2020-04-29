using Attributes;
using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;
using funge_98.Parsers;

namespace funge_98.Languages
{
    [ContainerElement]
    public class Unefunge : FungeFamilyLanguage
    {
        public Unefunge(CommandProducer commandProducer, UnefungeFileParser parser) : base(new UnefungeContext(),
            commandProducer, parser)
        {
        }
    }
}