using System.Collections.Generic;
using System.Linq;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class BeginBlockCommand : Command
    {
        public override char Name { get; } = '{';
        protected override string RealExecute(FungeContext fungeContext)
        {
            var n = fungeContext.GetTopStackTopValues(1)[0];
            var newStack = new Stack<int>(n);
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
            
            foreach (var coord in storageOffset.Coords)
            {
                fungeContext.Stacks.Peek().Push(coord);
            }

            currentThread.StorageOffset = currentThread.CurrentPosition + currentThread.DeltaVector;
            fungeContext.Stacks.Push(newStack);
            return null;
        }
    }
}