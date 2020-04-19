using System;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands.ArithmeticCommand
{
    public class ArithmeticCommand : ICommand
    {
        private readonly Func<int, int, int> _func;

        protected ArithmeticCommand(Func<int, int, int> func, char name)
        {
            _func = func;
            Name = name;
        }

        public  char Name { get; }

        public string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(2);
            try
            {
                fungeContext.PushToTopStack(_func(values[1], values[0]));
            }
            catch (DivideByZeroException)
            {
                fungeContext.PushToTopStack(0);
                return "Divided by zero!";
            }

            return null;
        }
    }
}