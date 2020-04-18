using funge_98.ExecutionContexts;

namespace funge_98.Commands
{
    public abstract class Command
    {
        public string Execute(FungeContext fungeContext)
        {
            if (!fungeContext.IsSupported(this))
            {
                return $"{fungeContext.Version} not supporting  {Name} command";
            }
            
            var error =  RealExecute(fungeContext);
            fungeContext.MoveOnce();
            return error;
        }

        public abstract char Name { get; }

        public virtual bool CanTick => true;

        protected abstract string RealExecute(FungeContext fungeContext);
    }
}