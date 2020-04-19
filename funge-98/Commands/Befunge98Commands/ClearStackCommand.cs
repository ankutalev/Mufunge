using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98Command]
    public class ClearStackCommand : ICommand
    {
        public char Name { get; } = 'n';

        public string RealExecute(FungeContext fungeContext)
        {
            if (fungeContext.Stacks.Count != 0)
            {
                fungeContext.Stacks.Pop();
            }

            return null;
        }
    }
}