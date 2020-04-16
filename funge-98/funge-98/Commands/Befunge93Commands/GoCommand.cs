using System.Collections.Generic;
using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class GoCommand : Command
    {
        private readonly Dictionary<char, Direction> _directions = new Dictionary<char, Direction>
        {
            {'<', Direction.WEST},
            {'>', Direction.EAST},
            {'^', Direction.NORTH},
            {'v', Direction.SOUTH},
            {'?', Direction.RANDOM}
        };

        public GoCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }

        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.SetDeltaVector(_directions[Name]);
            return null;
        }
    }
}