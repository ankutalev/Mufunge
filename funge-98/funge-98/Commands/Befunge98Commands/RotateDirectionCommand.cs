using System.Collections.Generic;
using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class RotateDirectionCommand : Command
    {
        private readonly Dictionary<char, Direction> _nameToDirection = new Dictionary<char, Direction>
        {
            {'[', Direction.WEST},
            {']', Direction.EAST},
        };

        public RotateDirectionCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }

        protected override string RealExecute(FungeContext fungeContext)
        {
            var cur = fungeContext.CurrentDirectionVector;
            fungeContext.CurrentDirectionVector = cur.Rotate(_nameToDirection[Name]);
            return null;
        }
    }
}