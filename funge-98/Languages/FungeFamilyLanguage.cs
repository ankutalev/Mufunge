using System.Linq;
using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;
using funge_98.Parsers;

namespace funge_98.Languages
{
    public abstract class FungeFamilyLanguage
    {
        private readonly FungeContext _executionContext;
        private readonly CommandProducer _commandProducer;
        private readonly ISourceCodeParser _parser;

        protected FungeFamilyLanguage(FungeContext executionContext, CommandProducer commandProducer, ISourceCodeParser parser)
        {
            _executionContext = executionContext;
            _commandProducer = commandProducer;
            _parser = parser;
        }
        
        public int Ticks => _executionContext.Ticks;

        public string NextStep()    
        {
            //todo need think about it
            
            foreach (var thread in _executionContext.Threads)
            {
                _executionContext.CurrentThread = thread;
                var commandName = _executionContext.GetCellValue(_executionContext.CurrentThread.CurrentPosition);
                var command = _commandProducer.GetCommand(commandName);
                command.Execute(_executionContext);
                _executionContext.MoveCurrentThread();
            }
            _executionContext.Threads = _executionContext.SpawnedThreads.Concat(_executionContext.Threads).ToList();
            return null;
        }

        public string RunProgram(string filename, bool onlyStandardExtension)
        {
            _executionContext.InitField(_parser.GetSourceCode(filename,onlyStandardExtension));
            string error = null;
            while (error == null && _executionContext.InterpreterAlive)
            {
                error = NextStep();
            }

            return error;
        }

        public int ExitCode => _executionContext.ExitCode;
    }
}