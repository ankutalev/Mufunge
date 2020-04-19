using System;
using System.Collections.Generic;
using System.Linq;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands.MoveCommand
{
    public abstract class MoveCommand : ICommand
    {
        private readonly Dictionary<char, DeltaVector> _directions = new Dictionary<char, DeltaVector>
        {
            {'<', new DeltaVector(-1,0,0)},
            {'>', new DeltaVector(1,0,0)},
            {'^', new DeltaVector(0,-1,0)},
            {'v', new DeltaVector(0,1,0)},
        };

        protected MoveCommand(char name)
        {
            Name = name;
        }

        public char Name { get; }

        public string RealExecute(FungeContext fungeContext)
        {
            var newDelta = Name switch
            {
                '?' => _directions.ToArray()[new Random().Next(0,4)].Value,
                _ => _directions[Name]
            };
            fungeContext.CurrentThread.DeltaVector = newDelta;
            return null;
        }
    }
}