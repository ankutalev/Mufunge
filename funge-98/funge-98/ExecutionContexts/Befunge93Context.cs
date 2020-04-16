using System;
using System.Collections.Generic;
using funge_98.Enums;
using funge_98.Exceptions;
using funge_98.Parsers;

namespace funge_98.ExecutionContexts
{
    public class Befunge93Context : FungeContext
    {
        private readonly char[,] _field = new char[25, 80];

        private readonly InstructionPointer _instructionPointer = new InstructionPointer
        {
            StorageOffset = new DeltaVector(0, 0, 0),
            DeltaVector = new DeltaVector(1, 0, 0),
            CurrentPosition = new DeltaVector(0, 0, 0)
        };

        private readonly List<DeltaVector> _constantVectors = new List<DeltaVector>
        {
            new DeltaVector(0, -1, 0),
            new DeltaVector(0, 1, 0),
            new DeltaVector(1, 0, 0),
            new DeltaVector(-1, 0, 0)
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


        public override string Version { get; } = "Befunge-93";
        public override bool InterpreterAlive { get; protected set; } = true;

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

        public override void SetDeltaVector(Direction direction)
        {
            if (direction == Direction.RANDOM)
            {
                var r = new Random();
                _instructionPointer.DeltaVector = _constantVectors[r.Next(0, 4)];
            }
            else
            {
                _instructionPointer.DeltaVector = _constantVectors[(int) direction];
            }
        }

        public override void MoveOnce()
        {
            _instructionPointer.CurrentPosition += _instructionPointer.DeltaVector;
            _instructionPointer.CurrentPosition.X %= 80;
            _instructionPointer.CurrentPosition.Y %= 25;
        }

        public override char GetCurrentCommandName()
        {
            return _field[_instructionPointer.CurrentPosition.Y, _instructionPointer.CurrentPosition.X];
        }

        public override void ToggleStringMode()
        {
            while (true)
            {
                MoveOnce();
                var c = GetCurrentCommandName();
                if (c=='"')
                    break;
                PushToTopStack(c);
            }
        }

        public override void Trampoline()
        {
            _instructionPointer.CurrentPosition += _instructionPointer.DeltaVector;
        }

        public override void ProcessSpace()
        {
        }

        public override void StopCurrentThread()
        {
            InterpreterAlive = false;
        }

        protected override DeltaVector GetTargetModifiedCell(int x, int y, int z)
        {
            return new DeltaVector(x, y, 0);
        }

        protected override void ModifyCell(DeltaVector cell, int value)
        {
            _field[cell.Y, cell.X] = (char) value;
        }

        protected override int GetCellValue(DeltaVector cell)
        {
            return _field[cell.Y, cell.X];
        }
    }
}