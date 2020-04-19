using System;
using System.Collections.Generic;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98Command]
    public class FingerPrintCommand : ICommand
    {
        private bool _firstMet = true;
        private readonly Stack<Func<FungeContext, string>> _keyBindings = new Stack<Func<FungeContext, string>>();

        public FingerPrintCommand(char name)
        {
            Name = name;
        }

        public char Name { get; }

        public string RealExecute(FungeContext fungeContext)
        {
            if (_firstMet)
            {
                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                _firstMet = false;
                return null;
            }

            if (_keyBindings.Count == 0)
            {
                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                return null;
            }

            return _keyBindings.Peek().Invoke(fungeContext);
        }

        public void ApplyAlias(Func<FungeContext, string> keyBinding)
        {
            _keyBindings.Push(keyBinding);
        }

        public void UnloadTopAlias()
        {
            _keyBindings.Pop();
        }
    }
}