using System;
using System.Collections.Generic;
using System.Linq;
using funge_98.Enums;

namespace funge_98.ExecutionContexts
{
    public class Befunge93 : FungeContext
    {
        private readonly Stack<int> _values = new Stack<int>();

        private readonly InstructionPointer _instructionPointer = new InstructionPointer
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


        public override int[] GetStackTopValues(int count)
        {
            var res =  _values.ToArray().Concat(Enumerable.Repeat(count - _values.Count, 0)).ToArray();
            _values.Clear();
            return res;
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