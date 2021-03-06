using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class EndBlockCommand : ICommand
    {
        public char Name { get; } = '}';

        public string RealExecute(FungeContext fungeContext)
        {
            if (fungeContext.CurrentThread.Stacks.Count < 2)
            {
                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                return null;
            }

            //get n values from toss
            var n = fungeContext.GetTopStackTopValues(1)[0];
            var values = n > 0 ? fungeContext.GetTopStackTopValues(n) : new int[0];
            //remove toss
            fungeContext.CurrentThread.Stacks.Pop();

            // restore offset
            var storageOffset = fungeContext.GetTopStackTopValues(fungeContext.Dimension);
            fungeContext.CurrentThread.StorageOffset = new DeltaVector(storageOffset.Reverse().ToArray());

            //
            if (n < 0)
            {
                fungeContext.GetTopStackTopValues(-n);
            }
            else
            {
                foreach (var value in values.Reverse())
                {
                    fungeContext.CurrentThread.Stacks.Peek().Push(value);
                }
            }

            return null;
        }
    }
}