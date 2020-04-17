using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class ReflectDirectionCommand : Command
    {
        public override char Name { get; } = 'r';

        protected override string RealExecute(FungeContext fungeContext)
        {
            var curDirection = fungeContext.CurrentDirectionVector;
            fungeContext.CurrentDirectionVector = curDirection.Reflect();
            return null;
        }
    }
}