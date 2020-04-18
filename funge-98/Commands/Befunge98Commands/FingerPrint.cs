using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class FingerPrint : Command
    {
        private readonly ReflectDirectionCommand _reflectDirectionCommand;

        public FingerPrint(char name, ReflectDirectionCommand reflectDirectionCommand)
        {
            _reflectDirectionCommand = reflectDirectionCommand;
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            // _reflectDirectionCommand.Execute(fungeContext);
            return null;
        }
    }
}