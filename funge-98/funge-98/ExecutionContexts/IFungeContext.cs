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

            var top = _stacks.Peek();
            var res = top.ToArray().Concat(Enumerable.Repeat(count - top.Count, 0)).ToArray();
            
            for (int i = 0; i < count && top.Count!=0; i++)
            {
                top.Pop();
            }

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

        public void StorageGet()
        {
            var coords = GetTopStackTopValues(3);
            var value = GetCellValue(new DeltaVector(coords[2], coords[1], coords[0]));
            PushToTopStack(value);
        }

        protected abstract DeltaVector GetTargetModifiedCell(int x, int y, int z);
        protected abstract void ModifyCell(DeltaVector cell, int value);

        protected abstract int GetCellValue(DeltaVector cell);
    }
}