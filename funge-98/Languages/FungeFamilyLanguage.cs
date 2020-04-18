using System;
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
            _executionContext.InitField();
        }

        public int Tick { get; set; }

        public string NextStep()
        {
            //todo need think about it
            
            foreach (var thread in _executionContext.Threads)
            {
                var commandName = _executionContext.GetCellValue(_executionContext.CurrentThread.CurrentPosition);
                var command = _commandProducer.GetCommand(commandName);
                // Console.WriteLine("{0} {1} {2}", _executionContext.CurrentThread.CurrentPosition.X, _executionContext.CurrentThread.CurrentPosition.Y, (char) commandName);
                command.Execute(_executionContext);
                if (command.CanTick)
                    Tick += 1;
            }

            return null;
        }

        public string RunProgram()
        {
            string error = null;
            while (error == null && _executionContext.InterpreterAlive)
            {
                error = NextStep();
            }

            return error;
        }
    }
}