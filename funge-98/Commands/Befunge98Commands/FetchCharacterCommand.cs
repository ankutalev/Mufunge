using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class FetchCharacterCommand : ICommand
    {
        public char Name { get; } = '\'';

        public string RealExecute(FungeContext fungeContext)
        {
            fungeContext.MoveCurrentThread();
            var fetched = fungeContext.GetCellValue(fungeContext.CurrentThread.CurrentPosition);
            fungeContext.PushToTopStack(fetched);
            return null;
        }
    }
}