using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.Commands;
using funge_98.Enums;
using funge_98.FingerPrints;
using funge_98.Parsers;

namespace funge_98.ExecutionContexts
{
    [ContainerElement]
    public class Befunge98Context : FungeContext
    {
        private int [][] _field;

        internal override InstructionPointer CurrentThread { get; set; } = new InstructionPointer
        {
            StorageOffset = new DeltaVector(0, 0, 0),
            DeltaVector = new DeltaVector(1, 0, 0),
            CurrentPosition = new DeltaVector(0, 0, 0),
            Alive = true
        };

        private static readonly HashSet<char> SupportedCommands = new HashSet<char>
        {
            '+',
            '-',
            '*',
            '/',
            '%',
            '!',
            '`',
            '>',
            '<',
            '^',
            'v',
            '?',
            '_',
            '|',
            '"',
            ':',
            '\\',
            '$',
            '.',
            ',',
            '#',
            'g',
            'p',
            '&',
            '~',
            '@',
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            ' '
        };
                

        public Befunge98Context(List<IFingerPrint> fps) : base(SupportedCommands, fps)
        {
            
        }
        public override bool  IsSupported(ICommand command)
        {
            return true;
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

        public override string Version { get; } = "Befunge-98";
        public override int Dimension { get; } = 2;

        public override void InitField(IEnumerable<string> source)
        {
            var tmp = new List<string>();
            var maxLen = 0;
            foreach (var line in source)
            {
                if (line.Length > maxLen)
                {
                    maxLen = line.Length;
                }
                tmp.Add(line);
            }

            _field = new int[tmp.Count][];
            var i = 0;
            foreach (var line in tmp)
            {
                _field[i] = Enumerable.Repeat((int)' ', maxLen).ToArray();
                for (var j = 0; j < line.Length; j++)
                {
                    _field[i][j] = line[j];
                }

                i++;
            }
        }

        protected override bool PositionOutOfBounds(DeltaVector currentPosition)
        {
            if (currentPosition.Y < 0 || currentPosition.Y >= _field.Length)
                return true;
            return currentPosition.X < 0 || currentPosition.X >= _field[currentPosition.Y].Length;
        }

        public override void ProcessSpace()
        {
        }


        protected override void ModifyCell(DeltaVector cell, int value)
        {
            //todo ))))))))))) nu i nasral
            var targetY = cell.Y;
            var targetX = cell.X;

            while (targetY < 0)
            {
                targetY += _field.Length;
            }
            targetY %= _field.Length;
            
            while (targetX < 0)
            {
                targetX += _field[targetY].Length;
            }
            targetX %= _field[targetY].Length;
            
            _field[targetY][targetX] =  value;
        }

        public override int GetCellValue(DeltaVector cell)
        {
            return PositionOutOfBounds(cell) ? 0 : _field[cell.Y][ cell.X];
        }
    }
}