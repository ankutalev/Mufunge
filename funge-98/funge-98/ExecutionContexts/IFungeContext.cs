using System.Collections.Generic;
using funge_98.Commands;
using funge_98.Enums;

namespace funge_98.ExecutionContexts
{
    public abstract class FungeContext
    {
        private readonly HashSet<char> _supportedCommands;

        protected FungeContext(HashSet<char> supportedCommands1)
        {
            _supportedCommands = supportedCommands1;
        }


        public bool IsSupported(Command command)
        {
            return _supportedCommands.Contains(command.Name);
        }

        public abstract bool GetStackTopValues(int count, out int[] values);
        public abstract void PushToStack(int value);
        public abstract void SetDeltaVector(Direction direction);
    }
}