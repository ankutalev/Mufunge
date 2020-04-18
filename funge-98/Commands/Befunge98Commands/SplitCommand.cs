using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class SplitCommand : Command
    {
        private readonly ReflectDirectionCommand _reflectDirectionCommand;

        public SplitCommand(ReflectDirectionCommand reflectDirectionCommand)
        {
            _reflectDirectionCommand = reflectDirectionCommand;
        }

        public override char Name { get; } = 't';
        protected override string RealExecute(FungeContext fungeContext)
        {
            return _reflectDirectionCommand.Execute(fungeContext);
        }
    }
}