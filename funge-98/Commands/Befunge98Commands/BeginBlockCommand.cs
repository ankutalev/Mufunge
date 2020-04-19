using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]

    public class BeginBlockCommand : ICommand
    {
        public char Name { get; } = '{';

        public string RealExecute(FungeContext fungeContext)
        {
            var n = fungeContext.GetTopStackTopValues(1)[0];
            var newStack = new Stack<int>();
            if (n > 0)
            {
                var values = fungeContext.GetTopStackTopValues(n).Reverse().ToArray();
                foreach (var value in values)
                {
                    newStack.Push(value);
                }
            }

            if (n < 0)
            {
                foreach (var i in Enumerable.Repeat(0,-n))
                {
                    fungeContext.Stacks.Peek().Push(i);
                }
            }

            var currentThread = fungeContext.CurrentThread;
            var storageOffset = currentThread.StorageOffset;

            for (int i = 0; i < fungeContext.Dimension; i++)
            { 
                fungeContext.Stacks.Peek().Push(storageOffset.Coords[i]);
            }

            currentThread.StorageOffset = currentThread.CurrentPosition + currentThread.DeltaVector;
            fungeContext.Stacks.Push(newStack);
            return null;
        }
    }
}