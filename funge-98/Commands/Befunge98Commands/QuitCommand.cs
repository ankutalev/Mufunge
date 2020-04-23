using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [Funge98, ContainerElement]
    public class QuitCommand : ICommand
    {
        public char Name { get; } = 'q';
        public string RealExecute(FungeContext fungeContext)
        {
            fungeContext.Threads.ForEach(t=>t.Alive = false);
            fungeContext.ExitCode = fungeContext.GetTopStackTopValues(1)[0];
            return null;
        }
    }
}