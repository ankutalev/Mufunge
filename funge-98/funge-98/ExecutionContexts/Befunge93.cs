using System;
using System.Collections.Generic;
using funge_98.Enums;

namespace funge_98.ExecutionContexts
{
    public class Befunge93 : FungeContext
    {
        private InstructionPointer _instructionPointer = new InstructionPointer
        {
            StorageOffset = new DeltaVector(0, 0, 0),
            DeltaVector = new DeltaVector(1, 0, 0)
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
            '9'
        };

        public Befunge93() : base(SupportedCommands)
        {
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

        public override void ToggleStringMode()
        {
            throw new NotImplementedException();
        }

        public override void Trampoline()
        {
            _instructionPointer.CurrentPosition += _instructionPointer.DeltaVector;
        }

        public override void ProcessSpace()
        {
            throw new NotImplementedException();
        }

        public override void StopCurrentThread()
        {
            _instructionPointer = null; //todo think about it
        }

        protected override DeltaVector GetTargetModifiedCell(int x, int y, int z)
        {
            return new DeltaVector(x, y, 0);
        }

        protected override void ModifyCell(DeltaVector cell, int value)
        {
            throw new NotImplementedException();
        }

        protected override int GetCellValue(DeltaVector cell)
        {
            throw new NotImplementedException();
        }
    }
}