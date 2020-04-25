using System.Collections.Generic;
using Attributes;
using funge_98.Enums;
using funge_98.ExecutionContexts.Fields;
using funge_98.FingerPrints;

namespace funge_98.ExecutionContexts
{
    [Befunge93]
    public class Befunge93Context : FungeContext
    {
        internal override List<InstructionPointer> SpawnedThreads { get; set; }

        internal override InstructionPointer CurrentThread { get; set; } = new InstructionPointer
        {
            StorageOffset = new DeltaVector(0, 0, 0),
            DeltaVector = new DeltaVector(1, 0, 0),
            CurrentPosition = new DeltaVector(0, 0, 0),
            Alive = true
        };
        public Befunge93Context() : base(new List<IFingerPrint>(), new Befunge93Field())
        {
        }

        internal override List<InstructionPointer> Threads
        {
            get => new List<InstructionPointer> {CurrentThread};
            set { }
        }

        public override CustomSettings Settings
        {
            get => new CustomSettings
            {
                WarnIfCommandNotSupported = OptionStatus.NotSupported,
                IsConcurrent = OptionStatus.NotSupported,
                IsInputFileSupported = OptionStatus.NotSupported,
                IsOutputFileSupported = OptionStatus.NotSupported,
                IsSystemCallSupported = OptionStatus.NotSupported,
                UnimplementedPolicy = UnimplementedPolicy.WarnUser
            };
            set { }
        }

        public override string Version { get; } = "Befunge-93";
        public override int Dimension { get; } = 2;
        
    }
}