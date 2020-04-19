using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, UnefungeCommand]
    public class KillThreadCommand : ICommand
    {
        public char Name { get; } = '@';

        public string RealExecute(FungeContext fungeContext)
        {
            fungeContext.StopCurrentThread();
            return null;
        }
    }
}