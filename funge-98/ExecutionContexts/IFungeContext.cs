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

        internal abstract List<InstructionPointer> Threads { get; set; }
        
        internal abstract List<InstructionPointer> SpawnedThreads { get; }

        internal abstract InstructionPointer CurrentThread { get; set; }

        protected FungeContext(List<IFingerPrint> fps, IFungeField field)
        {
            _field = field;
            SupportedFingerPrints = fps;
        }

        public abstract CustomSettings Settings { get; set; }
        public List<IFingerPrint> SupportedFingerPrints { get; }


        public abstract string Version { get; }
        public abstract int Dimension { get; }

        public string PopString()
        {
            var res = Enumerable.Repeat('\0', 0);
            char c;
            while (CurrentThread.Stacks.Peek().Count != 0 && (c = (char) CurrentThread.Stacks.Peek().Pop()) != '\0')
            {
                res = res.Append(c);
            }

            return new string(res.ToArray());
        }

        public bool InterpreterAlive
        {
            get => Threads.Any(x => x.Alive);
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

        public int ExitCode { get; set; }
        public static string HandPrint => "Mufunge";
        public static int NumericVersion => 100;
        public string[] ProgramArguments { get; set; }

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
            if (CurrentThread.Stacks.Count == 0)
            {
                CurrentThread.Stacks.Push(new Stack<int>());
            }

            var res = new int[count];
            var top = CurrentThread.Stacks.Peek();
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
            if (CurrentThread.Stacks.Count == 0)
            {
                CurrentThread.Stacks.Push(new Stack<int>());
            }

            CurrentThread.Stacks.Peek().Push(value);
        }

        public void ModifyCell(DeltaVector target, int value) => _field.ModifyCell(target, value);

        public void MoveCurrentThread()
        {
            CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
            if (!_field.IsOutOfBounds(CurrentThread.CurrentPosition))
                return;

            CurrentThreadDeltaVector = CurrentThreadDeltaVector.Reflect();
            do
            {
                CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
            } while (_field.IsOutOfBounds(CurrentThread.CurrentPosition));

            do
            {
                CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
            } while (!_field.IsOutOfBounds(CurrentThread.CurrentPosition));


            CurrentThreadDeltaVector = CurrentThreadDeltaVector.Reflect();
            CurrentThread.CurrentPosition += CurrentThreadDeltaVector;
        }

        public void StopCurrentThread() => CurrentThread.Alive = false;
        public int GetCellValue(DeltaVector cell) => _field.GetValue(cell);

        public DeltaVector GetLeastPoint() => _field.GetLeastPoint();

        public DeltaVector GetGreatestPoint() => _field.GetGreatestPoint();
    }
}