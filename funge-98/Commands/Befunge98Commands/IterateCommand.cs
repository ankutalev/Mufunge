using System;
using System.Collections.Generic;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [Funge98]
    public class IterateCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        public IterateCommand(List<ICommand> commands)
        {
            _commands = commands;
        }

        public char Name { get; } = 'k';

        public string RealExecute(FungeContext fungeContext)
        {
            var n = fungeContext.GetTopStackTopValues(1)[0];
            if (n == 0)
            {
                fungeContext.MoveOnce();
                return null;
            }

            if (n < 0)
            {
                return "k command behavior not specified when n is negative";
            }

            var nextPos = fungeContext.CurrentThread.CurrentPosition;
            while (true)
            {
                nextPos += fungeContext.CurrentThreadDeltaVector;
                var nextCommand = fungeContext.GetCellValue(nextPos);
                if (nextCommand == ';' || nextCommand == ' ')
                    continue;
                var command = _commands.Find(c => c.Name == nextCommand);
                for (int i = 0; i < n; i++)
                {
                    command?.Execute(fungeContext);
                }

                return null;
            }
        }
    }
}