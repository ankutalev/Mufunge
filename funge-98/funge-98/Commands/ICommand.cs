using funge_98.ExecutionContexts;

namespace funge_98.Commands
{
    public abstract class Command
    {
        public string Execute(FungeContext fungeContext)
        {
            if (!fungeContext.IsSupported(this))
            {
                return $"{nameof(fungeContext)} not supporting  {Name} command";
            }

            return RealExecute(fungeContext);
        }

        public abstract char Name { get; }

        protected abstract string RealExecute(FungeContext fungeContext);
    }
}