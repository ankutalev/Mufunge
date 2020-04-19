using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class StoreCharacterCommand : ICommand
    {
        public char Name { get; } = 's';

        public string RealExecute(FungeContext fungeContext)
        {
            var value = fungeContext.GetTopStackTopValues(1)[0];
            fungeContext.ModifyCell(fungeContext.CurrentThread.CurrentPosition + fungeContext.CurrentThreadDeltaVector,
                value);
            fungeContext.MoveOnce();
            return null;
        }
    }
}