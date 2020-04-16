using System.Collections.Generic;
using System.Linq;
using funge_98.Commands;
using funge_98.Enums;

namespace funge_98.ExecutionContexts
{
    public abstract class FungeContext
    {
        private readonly HashSet<char> _supportedCommands;
        private readonly Stack<Stack<int>> _stacks = new Stack<Stack<int>>();

        protected FungeContext(HashSet<char> supportedCommands1)
        {
            _stacks.Push(new Stack<int>());
            _supportedCommands = supportedCommands1;
        }

        public bool IsSupported(Command command)
        {
            return _supportedCommands.Contains(command.Name);
        }

        public int[] GetTopStackTopValues(int count)
        {
            if (_stacks.Count == 0)
            {
                _stacks.Push(new Stack<int>());
            }

            var res = _stacks.Peek().ToArray().Concat(Enumerable.Repeat(count - _stacks.Count, 0)).ToArray();
            _stacks.Peek().Clear();
            return res;
        }

        public void PushToTopStack(int value)
        {
            if (_stacks.Count == 0)
            {
                _stacks.Push(new Stack<int>());
            }

            _stacks.Peek().Push(value);
        }

        public abstract void SetDeltaVector(Direction direction);

        public void StoragePut()
        {
            var values = GetTopStackTopValues(4);
            var targetCell = GetTargetModifiedCell(values[2], values[1], values[0]);
            ModifyCell(targetCell, values.Reverse().FirstOrDefault(x => x != 0));
        }

        protected abstract DeltaVector GetTargetModifiedCell(int x, int y, int z);
        protected abstract void ModifyCell(DeltaVector cell, int value);
    }
}