using System.Collections.Generic;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class IterateCommand : Command
    {
        private readonly List<Command> _commands;

        public IterateCommand (List<Command> commands)
        {
            _commands = commands;
        }

       public override char Name { get; } = 'k';
        protected override string RealExecute(FungeContext fungeContext)
        {
            var n = fungeContext.GetTopStackTopValues(1)[0];
            if (n < 0)
            {
                return "k command behavior not specified when n is negative";
            }

            while (true)
            {
                var nextPos = fungeContext.CurrentThread.CurrentPosition + fungeContext.CurrentThreadDeltaVector;
                var nextCommand = fungeContext.GetCellValue(nextPos);
                if (nextCommand == ';' || nextCommand == ' ') 
                    continue;
                var command = _commands.Find(c => c.Name == nextCommand);
                for (int i = 0; i < n; i++)
                {
                    command.Execute(fungeContext);
                }

                return null;
            }
        }
    }
}