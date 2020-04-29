using System.Collections.Generic;
using Attributes;
using funge_98.Enums;
using funge_98.ExecutionContexts.Fields;
using funge_98.FingerPrints;

namespace funge_98.ExecutionContexts
{
    [Unefunge, ContainerElement]
    public class UnefungeContext : FungeContext
    {
        public UnefungeContext() : base(new List<IFingerPrint>(), new UnefungeField())
        {
        }

        internal override List<InstructionPointer> SpawnedThreads { get; } = new List<InstructionPointer>();

        internal override InstructionPointer CurrentThread { get; set; } = new InstructionPointer
        {
            StorageOffset = new DeltaVector(0, 0, 0),
            DeltaVector = new DeltaVector(1, 0, 0),
            CurrentPosition = new DeltaVector(0, 0, 0),
            Alive = true
        };

        internal override List<InstructionPointer> Threads
        {
            get => new List<InstructionPointer> {CurrentThread};
            set { }
        }

        public override CustomSettings Settings
        {
            get => new CustomSettings
            {
                WarnIfCommandNotSupported = OptionStatus.Enable,
                IsConcurrent = OptionStatus.NotSupported,
                IsInputFileSupported = OptionStatus.NotSupported,
                IsOutputFileSupported = OptionStatus.NotSupported,
                IsSystemCallSupported = OptionStatus.NotSupported,
                UnimplementedPolicy = UnimplementedPolicy.WarnUser,
                SgmlSpaces = OptionStatus.NotSupported
            };
            set { }
        }

        public override string Version { get; } = "Unefunge";
        public override int Dimension { get; } = 1;
    }
}