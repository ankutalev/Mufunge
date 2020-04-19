using System.Collections.Generic;
using funge_98.Enums;
using funge_98.Exceptions;
using funge_98.FingerPrints;
using funge_98.Parsers;

namespace funge_98.ExecutionContexts
{
    public class Befunge93Context : FungeContext
    {
        private readonly char[,] _field = new char[25, 80];

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

        public Befunge93Context() : base(SupportedCommands, new List<IFingerPrint>())
        {
            for (var i = 0; i < _field.GetLength(0); i++)
            {
                for (var j = 0; j < _field.GetLength(1); j++)
                {
                    _field[i, j] = ' ';
                }
            }
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

        public override void InitField(IEnumerable<string> source)
        {
            var y = 0;
            foreach (var line in source)
            {
                if (y > 25)
                {
                    throw new IncorrectFileFormatException(
                        "Befunge-93 source code file can contains only 25 lines maximum");
                }

                if (line.Length > 80)
                {
                    throw new IncorrectFileFormatException(
                        "Befunge-93 source code file line can contains only 80 chars");
                }

                for (var x = 0; x < line.Length; x++)
                {
                    _field[y, x] = line[x];
                }

                y++;
            }
        }

        protected override bool PositionOutOfBounds(DeltaVector currentPosition)
        {
            return currentPosition.X < 0 || currentPosition.X >= 80 || currentPosition.Y < 0 || currentPosition.Y >= 25;
        }

        public override void ProcessSpace()
        {
        }


        protected override void ModifyCell(DeltaVector cell, int value)
        {
            _field[cell.Y, cell.X] = (char) value;
        }

        public override int GetCellValue(DeltaVector cell)
        {
            return PositionOutOfBounds(cell) ? 0 : _field[cell.Y, cell.X];
        }
    }
}