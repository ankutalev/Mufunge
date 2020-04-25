using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class SplitCommand : ICommand
    {
        public char Name { get; } = 't';

        public string RealExecute(FungeContext fungeContext)
        {
            var newThread = new InstructionPointer
            {
                Alive = true,
                DeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect(),
                CurrentPosition = fungeContext.CurrentThread.CurrentPosition.Copy(),
                StorageOffset = fungeContext.CurrentThread.StorageOffset.Copy(),
                Stacks = new Stack<Stack<int>>(),
            };
            newThread.CurrentPosition += newThread.DeltaVector;
            
            foreach (var stack in fungeContext.CurrentThread.Stacks.Reverse())
            {
                newThread.Stacks.Push(new Stack<int>());
                foreach (var i in stack.Reverse())
                {
                    newThread.Stacks.Peek().Push(i);
                }
            }
            fungeContext.SpawnedThreads.Add(newThread);
            return null;
        }
    }
}