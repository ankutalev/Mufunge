using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class FetchCharacterCommand : Command
    {
        public override char Name { get; } = '\'';
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.MoveOnce();
            var fetched = fungeContext.GetCurrentCommandName();
            fungeContext.PushToTopStack(fetched);
            return null;
        }
    }
}