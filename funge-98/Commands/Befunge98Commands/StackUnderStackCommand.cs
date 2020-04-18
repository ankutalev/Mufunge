using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class StackUnderStackCommand : Command
    {
        private readonly ReflectDirectionCommand _reflectDirectionCommand;

        public StackUnderStackCommand(ReflectDirectionCommand reflectDirectionCommand)
        {
            _reflectDirectionCommand = reflectDirectionCommand;
        }
        public override char Name { get; } = 'u';
        protected override string RealExecute(FungeContext fungeContext)
        {
            var n = fungeContext.GetTopStackTopValues(1)[0];
            if (n == 0)
            {
                return null;
            }

            if (fungeContext.Stacks.Count == 1)
            {
                _reflectDirectionCommand.Execute(fungeContext);
                return null;
            }
            
            if (n > 0)
            {
                var top = fungeContext.Stacks.Pop();
                var values = fungeContext.GetTopStackTopValues(n);
                foreach (var value in values)
                {
                    top.Push(value);
                }
                fungeContext.Stacks.Push(top);
            }
            else
            {
                var values = fungeContext.GetTopStackTopValues(n);
                var top = fungeContext.Stacks.Pop();
                foreach (var value in values)
                {
                    fungeContext.Stacks.Peek().Push(value);
                }
                fungeContext.Stacks.Push(top);
            }
            return null;
        }
    }
}