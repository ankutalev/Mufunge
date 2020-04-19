using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands
{
    public interface ICommand
    {
        public string Execute(FungeContext fungeContext)
        {
            if (!fungeContext.IsSupported(this))
            {
                if (fungeContext.Settings.WarnIfCommandNotSupported==OptionStatus.Enable)
                {
                    return $"{fungeContext.Version} not supporting  {Name} command";
                }
                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                return null;
            }
            
            var error =  RealExecute(fungeContext);
            fungeContext.MoveOnce();
            return error;
        }

        public char Name { get; }

        public bool CanTick => true;

        public string RealExecute(FungeContext fungeContext);
    }
}