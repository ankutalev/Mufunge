using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98Command]

    public class ReflectDirectionCommand : ICommand
    {
        public char Name { get; } = 'r';

        public string RealExecute(FungeContext fungeContext)
        {
            var curDirection = fungeContext.CurrentThreadDeltaVector;
            fungeContext.CurrentThreadDeltaVector = curDirection.Reflect();
            return null;
        }
    }
}