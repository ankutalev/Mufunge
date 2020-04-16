using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;

namespace funge_98.Languages
{
    public abstract class FungeFamilyLanguage
    {
        private readonly FungeContext _executionContext;
        private readonly CommandProducer _commandProducer;

        protected FungeFamilyLanguage(FungeContext executionContext, CommandProducer commandProducer)
        {
            _executionContext = executionContext;
            _commandProducer = commandProducer;
        }

        public string NextTick()
        {
           var commandName = _executionContext.GetCurrentCommandName();
           return _commandProducer.GetCommand(commandName).Execute(_executionContext);
        }

         public string RunProgram()
        {
            string error = null;
            while (error==null)
            {
                error = NextTick();
            }
            return error;
        }
    }
}