using System;
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

        public static int Tick { get; set; } = -1;

        public string NextStep()
        {
            //todo need think about it
            
            foreach (var thread in _executionContext.Threads)
            {
                var commandName = _executionContext.GetCellValue(_executionContext.CurrentThread.CurrentPosition);
                var command = _commandProducer.GetCommand(commandName);
                if (command.CanTick)
                    Tick += 1;
                if (Tick == 7500)
                {
                    ;
                }
                command.Execute(_executionContext);
               
            }

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