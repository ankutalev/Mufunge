using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.Commands;
using funge_98.ExecutionContexts.Fields;
using funge_98.FingerPrints;

namespace funge_98.ExecutionContexts
{
    public abstract class FungeContext
    {
        private readonly IFungeField _field;
        private readonly Dictionary<char, bool> _supportedCommands = new Dictionary<char, bool>();
        internal Stack<Stack<int>> Stacks { get; set; } = new Stack<Stack<int>>();

        internal abstract List<InstructionPointer> Threads { get; set; }

        internal abstract InstructionPointer CurrentThread { get; set; }

        protected FungeContext(List<IFingerPrint> fps, IFungeField field)
        {
            _field = field;
            Stacks.Push(new Stack<int>());
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

        public void InitField(IEnumerable<string> source) => _field.InitField(source);

        public bool IsSupported(ICommand command)
        {
            if (_supportedCommands.TryGetValue(command.Name, out var res))
                return res;


            var myVersion = GetType().GetCustomAttributes(true).First();
            var commandVersion = command.GetType().GetCustomAttributes(true).First(t => !(t is ContainerElement));

            switch (myVersion)
            {
                case Trefunge _:
                    _supportedCommands.Add(command.Name, true);
                    return true;
                case Funge98 _:
                {
                    var supported = !(commandVersion is Trefunge);
                    _supportedCommands.Add(command.Name, supported);
                    return supported;
                }
                case Befunge93 _:
                {
                    var supported = commandVersion is Befunge93 || commandVersion is Unefunge;
                    _supportedCommands.Add(command.Name, supported);
                    return supported;
                }
                case Unefunge _:
                {
                    var supported = commandVersion is Unefunge;
                    _supportedCommands.Add(command.Name, supported);
                    return supported;
                }
                default:
                    return false;
            }
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

        public void ModifyCell(DeltaVector target, int value) => _field.ModifyCell(target, value);

        public void StorageGet()
        {
            var coords = GetTopStackTopValues(Dimension);
            var value = GetCellValue(new DeltaVector(coords.Reverse().ToArray()));
            PushToTopStack(value);
        }

        public void MoveOnce()
        {
            CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
            if (!_field.IsOutOfBounds(CurrentThread.CurrentPosition))
                return;

            CurrentThreadDeltaVector = CurrentThreadDeltaVector.Reflect();
            do
            {
                CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
            } while (!_field.IsOutOfBounds(CurrentThread.CurrentPosition));

            CurrentThreadDeltaVector = CurrentThreadDeltaVector.Reflect();
            CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
        }

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
        public int GetCellValue(DeltaVector cell) => _field.GetValue(cell);
    }
}