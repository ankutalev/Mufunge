using System.Collections.Generic;

namespace funge_98.ExecutionContexts
{
    public class InstructionPointer
    {
        private static int _nextId;
        public char PreviousCommandName;

        public InstructionPointer()
        {
            Id = _nextId;
            _nextId++;
        }

        public DeltaVector DeltaVector { get; set; }

        public DeltaVector CurrentPosition { get; set; }
        public DeltaVector StorageOffset { get; set; }

        public bool Alive { get; set; } = true;
        public int Id { get; }
        
        internal Stack<Stack<int>> Stacks { get; set; } = new Stack<Stack<int>>();
        public bool StringMode { get; set; }
    }
}