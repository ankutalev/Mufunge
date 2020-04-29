using System.Linq;
using funge_98.Commands;
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
        
        public int Ticks { get; set; }

        public string NextStep()    
        {
            
            foreach (var thread in _executionContext.Threads)
            {
                _executionContext.CurrentThread = thread;
                var res = ICommand.Notick;
                while (res == ICommand.Notick)
                {
                    var commandName = _executionContext.GetCellValue(_executionContext.CurrentThread.CurrentPosition);
                    var command = _commandProducer.GetCommand(commandName);
                    res = command.Execute(_executionContext);
                    _executionContext.MoveCurrentThread();
                }
            }
            Ticks++;
            _executionContext.Threads =_executionContext.SpawnedThreads.Concat(_executionContext.Threads.Where(t=>t.Alive)).ToList();
            _executionContext.SpawnedThreads.Clear();
            return null;
        }

        public string RunProgram(string[] args, bool onlyStandardExtension)
        {
            _executionContext.InitField(_parser.GetSourceCode(args[0], onlyStandardExtension));
            _executionContext.ProgramArguments = args;
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