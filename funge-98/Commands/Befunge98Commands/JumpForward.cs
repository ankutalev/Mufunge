using System;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98Command]
    public class JumpForward : ICommand
    {
        public char Name { get; } = 'j';

        public string RealExecute(FungeContext fungeContext)
        {
            var n = fungeContext.GetTopStackTopValues(1)[0];
            var delta = n < 0 ? fungeContext.CurrentThreadDeltaVector.Reflect() : fungeContext.CurrentThreadDeltaVector;
            for (int i = 0; i < Math.Abs(n); i++)
            {
                fungeContext.CurrentThread.CurrentPosition += delta;
            }

            return null;
        }
    }
}