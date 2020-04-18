using System.Collections.Generic;
using funge_98.Enums;
using funge_98.Exceptions;
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

        public Befunge93Context(ISourceCodeParser parser) : base(SupportedCommands, parser)
        {
            for (var i = 0; i < _field.GetLength(0); i++)
            {
                for (var j = 0; j < _field.GetLength(1); j++)
                {
                    _field[i, j] = ' ';
                }
            }
        }

        internal override List<InstructionPointer> Threads { get => new List<InstructionPointer>{ CurrentThread}; set {} }

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
        public override void InitField()
        {
            var y = 0;
            foreach (var line in Parser.GetSourceCode())
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
        public override void MoveOnce()
        {
            CurrentThread.CurrentPosition += CurrentThread.DeltaVector;
            CurrentThread.CurrentPosition.X = (CurrentThread.CurrentPosition.X + 80) % 80;
            CurrentThread.CurrentPosition.Y = (CurrentThread.CurrentPosition.Y + 25) % 25;
        }

        public override char GetCurrentCommandName()
        {
            return _field[CurrentThread.CurrentPosition.Y, CurrentThread.CurrentPosition.X];
        }

        public override void Trampoline()
        {
            CurrentThread.CurrentPosition += CurrentThread.DeltaVector;
        }

        public override void ProcessSpace()
        {
        }

        public override void StopCurrentThread()
        {
            InterpreterAlive = false;
        }

        protected override void ModifyCell(DeltaVector cell, int value)
        {
            _field[cell.Y, cell.X] = (char) value;
        }

        protected override int GetCellValue(DeltaVector cell)
        {
            if (cell.Y >= 25 || cell.Y < 0 || cell.X < 0 || cell.X >= 80)
                return 0;
            return _field[cell.Y, cell.X];
        }
    }
}