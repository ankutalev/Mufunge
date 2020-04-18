using System.Collections.Generic;
using System.Linq;
using funge_98.Commands;
using funge_98.Enums;
using funge_98.Parsers;

namespace funge_98.ExecutionContexts
{
    public abstract class FungeContext
    {
        private readonly HashSet<char> _supportedCommands;
        protected readonly ISourceCodeParser Parser;
        internal Stack<Stack<int>> Stacks { get; set; } = new Stack<Stack<int>>();

        internal List<InstructionPointer> Threads { get; set; }
        
        internal InstructionPointer CurrentThread { get; set; }

        protected FungeContext(HashSet<char> supportedCommands1, ISourceCodeParser parser)
        {
            Stacks.Push(new Stack<int>());
            _supportedCommands = supportedCommands1;
            Parser = parser;
        }
        
        public abstract CustomSettings Settings { get; set; }

        public abstract string Version { get; }
        public abstract int Dimension { get; }

        public abstract bool InterpreterAlive { get; protected set; }
        public abstract DeltaVector CurrentDirectionVector { get; set; }

        public abstract void InitField();

        public bool IsSupported(Command command)
        {
            return _supportedCommands.Contains(command.Name);
        }

        public int[] GetTopStackTopValues(int count)
        {
            if (Stacks.Count == 0)
            {
                Stacks.Push(new Stack<int>());
            }

            var res = new int[count];
            var top = Stacks.Peek();
            for (var i = 0; i < count; i++)
            {
                if (top.Count == 0)
                {
                    res[i] = 0;
                }
                else
                {
                    res[i] = top.Pop();
                }
            }

            return res;
        }

        public void PushToTopStack(int value)
        {
            if (Stacks.Count == 0)
            {
                Stacks.Push(new Stack<int>());
            }

            Stacks.Peek().Push(value);
        }

        public abstract void SetDeltaVector(Direction direction);

        public void StoragePut()
        {
            var values = GetTopStackTopValues(Dimension + 1);
            var targetCell = new DeltaVector(values.Reverse().Skip(1).ToArray());
            ModifyCell(targetCell, values.Last());
        }

        public void StorageGet()
        {
            var coords = GetTopStackTopValues(Dimension);
            var value = GetCellValue(new DeltaVector(coords.Reverse().ToArray()));
            PushToTopStack(value);
        }

        public abstract void MoveOnce();
        public abstract char GetCurrentCommandName();

        public void ToggleStringMode()
        {
            while (true)
            {
                MoveOnce();
                var c = GetCurrentCommandName();
                if (c == '"')
                    break;
                PushToTopStack(c);
            }
        }

        public abstract void Trampoline();
        public abstract void ProcessSpace();
        public abstract void StopCurrentThread();
        protected abstract void ModifyCell(DeltaVector cell, int value);
        protected abstract int GetCellValue(DeltaVector cell);
    }
}