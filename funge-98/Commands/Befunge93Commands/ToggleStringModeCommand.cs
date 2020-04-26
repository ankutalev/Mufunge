using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, Unefunge]
    public class ToggleStringModeCommand : ICommand
    {
        public char Name { get; } = '"';

        public string RealExecute(FungeContext fungeContext)
        {
            fungeContext.CurrentThread.StringMode = !fungeContext.CurrentThread.StringMode;
            return null;
        }
    }
}