namespace funge_98.ExecutionContexts
{
    public class InstructionPointer
    {
        public DeltaVector DeltaVector { get; set; }

        public DeltaVector CurrentPosition { get; set; }
        public DeltaVector StorageOffset { get; set; }

        public bool Alive { get; set; } = true;
    }
}