using System.Collections.Generic;
using Attributes;
using funge_98.Enums;
using funge_98.ExecutionContexts.Fields;
using funge_98.FingerPrints;

namespace funge_98.ExecutionContexts
{
    [Funge98]
    public class Befunge98Context : FungeContext
    {
        internal override List<InstructionPointer> SpawnedThreads { get; } = new List<InstructionPointer>();

        internal sealed override InstructionPointer CurrentThread { get; set; } 


        public Befunge98Context(List<IFingerPrint> fps) : base(fps, new Funge98Field())
        {
            CurrentThread =  new InstructionPointer
            {
                StorageOffset = new DeltaVector(0, 0, 0),
                DeltaVector = new DeltaVector(1, 0, 0),
                CurrentPosition = new DeltaVector(0, 0, 0),
                Alive = true
            };
            Threads = new List<InstructionPointer> {CurrentThread};
        }

        internal sealed override List<InstructionPointer> Threads { get; set; }

        public override CustomSettings Settings
        {
            get =>
                new CustomSettings
                {
                    WarnIfCommandNotSupported = OptionStatus.NotSupported,
                    IsConcurrent = OptionStatus.Enable,
                    IsInputFileSupported = OptionStatus.Enable,
                    IsOutputFileSupported = OptionStatus.Enable,
                    IsSystemCallSupported = OptionStatus.Enable,
                    UnimplementedPolicy = UnimplementedPolicy.WarnUser,
                    SgmlSpaces =  OptionStatus.Enable
                };
            set { }
        }

        public override string Version { get; } = "Befunge-98";
        public override int Dimension { get; } = 2;
    }
}