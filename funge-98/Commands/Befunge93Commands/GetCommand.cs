using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, UnefungeCommand]
    public class GetCommand : ICommand
    {
        public char Name { get; } = 'g';

        public string RealExecute(FungeContext fungeContext)
        {
            fungeContext.StorageGet();
            return null;
        }
    }
}