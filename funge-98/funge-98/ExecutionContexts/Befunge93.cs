using System;
using System.Collections.Generic;
using funge_98.Enums;

namespace funge_98.ExecutionContexts
{
    public class Befunge93 : FungeContext
    {
        private readonly Stack<int> _values = new Stack<int>();

        private readonly InstructionPointer _instructionPointer = new InstructionPointer
        {
            StorageOffset = new DeltaVector(0,0,0),
            DeltaVector =  new DeltaVector(1,0,0)
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


        public override bool GetStackTopValues(int count, out int[] values)
        {
            if (_values.Count < count)
            {
                values = null;
                _values.Clear();
                return false;
            }

            values = new int[count];

            for (var i = 0; i < count; i++)
            {
                values[i] = _values.Pop();
            }

            return true;
        }

        public override void PushToStack(int value) => _values.Push(value);

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
    }
}