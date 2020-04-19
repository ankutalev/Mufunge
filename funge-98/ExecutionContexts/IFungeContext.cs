using System.Collections.Generic;
using System.Linq;
using funge_98.Commands;
using funge_98.Enums;
using funge_98.FingerPrints;
using funge_98.Parsers;

namespace funge_98.ExecutionContexts
{
    public abstract class FungeContext
    {
        private readonly HashSet<char> _supportedCommands;
        protected readonly ISourceCodeParser Parser;
        internal Stack<Stack<int>> Stacks { get; set; } = new Stack<Stack<int>>();

        internal abstract List<InstructionPointer> Threads { get; set; }

        internal abstract InstructionPointer CurrentThread { get; set; }

        protected FungeContext(HashSet<char> supportedCommands1, ISourceCodeParser parser, List<IFingerPrint> fps)
        {
            Stacks.Push(new Stack<int>());
            _supportedCommands = supportedCommands1;
            Parser = parser;
            SupportedFingerPrints = fps;
        }

        public abstract CustomSettings Settings { get; set; }
        public List<IFingerPrint> SupportedFingerPrints { get; }


        public abstract string Version { get; }
        public abstract int Dimension { get; }

        public bool InterpreterAlive
        {
            get => Threads.All(x => x.Alive);
            protected set
            {
                if (value)
                    CurrentThread.Alive = true;
                else
                    Threads.ForEach(x => x.Alive = false);
            }
        }

        public DeltaVector CurrentThreadDeltaVector
        {
            get => CurrentThread.DeltaVector;
            set => CurrentThread.DeltaVector = value;
        }

        public abstract void InitField();

        public virtual bool  IsSupported(ICommand command)
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


        public void StoragePut(DeltaVector target, int value)
        {
            ModifyCell(target, value);
        }

        public void StorageGet()
        {
            var coords = GetTopStackTopValues(Dimension);
            var value = GetCellValue(new DeltaVector(coords.Reverse().ToArray()));
            PushToTopStack(value);
        }

        public void MoveOnce()
        {
            CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
            if (!PositionOutOfBounds(CurrentThread.CurrentPosition)) 
                return;
            
            CurrentThreadDeltaVector = CurrentThreadDeltaVector.Reflect();
            do
            {
                CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
            }
            while (!PositionOutOfBounds(CurrentThread.CurrentPosition));

            CurrentThreadDeltaVector = CurrentThreadDeltaVector.Reflect();
            CurrentThread.CurrentPosition += CurrentThreadDeltaVector;


        }

        protected abstract bool PositionOutOfBounds(DeltaVector currentPosition);

        public void ToggleStringMode()
        {
            while (true)
            {
                MoveOnce();
                var c = GetCellValue(CurrentThread.CurrentPosition);
                if (c == '"')
                    break;
                PushToTopStack(c);
            }
        }

        public abstract void ProcessSpace();
        public void StopCurrentThread() => CurrentThread.Alive = false;
        protected abstract void ModifyCell(DeltaVector cell, int value);
        public abstract int GetCellValue(DeltaVector cell);
    }
}