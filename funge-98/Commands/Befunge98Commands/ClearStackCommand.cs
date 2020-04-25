using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class ClearStackCommand : ICommand
    {
        public char Name { get; } = 'n';

        public string RealExecute(FungeContext fungeContext)
        {
            if (fungeContext.CurrentThread.Stacks.Count != 0)
            {
                fungeContext.CurrentThread.Stacks.Peek().Clear();
            }

            return null;
        }
    }
}