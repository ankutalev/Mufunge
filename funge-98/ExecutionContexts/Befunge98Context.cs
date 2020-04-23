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
        internal override InstructionPointer CurrentThread { get; set; } = new InstructionPointer
        {
            StorageOffset = new DeltaVector(0, 0, 0),
            DeltaVector = new DeltaVector(1, 0, 0),
            CurrentPosition = new DeltaVector(0, 0, 0),
            Alive = true
        };


        public Befunge98Context(List<IFingerPrint> fps) : base( fps, new Funge98Field())
        {
            
        }

        internal override List<InstructionPointer> Threads
        {
            get => new List<InstructionPointer> {CurrentThread};
            set { }
        }

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
                    UnimplementedPolicy = UnimplementedPolicy.WarnUser
                };
            set { }
        }

        public override string Version { get; } = "Befunge-98";
        public override int Dimension { get; } = 2;
        public override void ProcessSpace()
        {
        }
        
        public override void ToggleStringMode()
        {
            while (true)
            {
                MoveOnce();
                var c = GetCellValue(CurrentThread.CurrentPosition);
                if (c == '"')
                    break;
                if (c == ' ')
                {
                    do
                    {
                        MoveOnce();
                    } while (GetCellValue(CurrentThread.CurrentPosition) == ' ');
                    CurrentThread.CurrentPosition += CurrentThreadDeltaVector.Reflect();
                }
                PushToTopStack(c);
            }
        }
    }
}