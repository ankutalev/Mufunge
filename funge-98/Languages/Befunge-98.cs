using Attributes;
using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;
using funge_98.Parsers;

namespace funge_98.Languages
{
    [ContainerElement]
    public class Befunge98 : FungeFamilyLanguage
    {
        public Befunge98(CommandProducer commandProducer, Befunge98FileParser fp) : base(new Befunge98Context(commandProducer.FingerPrints), commandProducer,fp)
        {
        }
    }
}