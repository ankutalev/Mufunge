using System.Collections.Generic;
using Attributes;
using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement]
    [Funge98Command]
    public class TurnCommand : ICommand
    {
        private readonly Dictionary<char, Direction> _nameToDirection = new Dictionary<char, Direction>
        {
            {'[', Direction.West},
            {']', Direction.East},
        };

        public TurnCommand(char name)
        {
            Name = name;
        }

        public char Name { get; }

        public string RealExecute(FungeContext fungeContext)
        {
            var cur = fungeContext.CurrentThreadDeltaVector;
            fungeContext.CurrentThreadDeltaVector = cur.Rotate(_nameToDirection[Name]);
            return null;
        }
    }
}