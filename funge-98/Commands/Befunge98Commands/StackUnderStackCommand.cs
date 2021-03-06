using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class StackUnderStackCommand : ICommand
    {
        public char Name { get; } = 'u';

        public string RealExecute(FungeContext fungeContext)
        {
            if (fungeContext.CurrentThread.Stacks.Count == 1)
            {
                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                return null;
            }

            var n = fungeContext.GetTopStackTopValues(1)[0];

            if (n == 0)
            {
                return null;
            }


            if (n > 0)
            {
                var top = fungeContext.CurrentThread.Stacks.Pop();
                var values = fungeContext.GetTopStackTopValues(n);
                foreach (var value in values)
                {
                    top.Push(value);
                }

                fungeContext.CurrentThread.Stacks.Push(top);
            }
            else
            {
                var values = fungeContext.GetTopStackTopValues(-n);
                var top = fungeContext.CurrentThread.Stacks.Pop();
                foreach (var value in values)
                {
                    fungeContext.CurrentThread.Stacks.Peek().Push(value);
                }

                fungeContext.CurrentThread.Stacks.Push(top);
            }

            return null;
        }
    }
}