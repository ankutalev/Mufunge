using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands
{
    public interface ICommand
    {
        public static string Notick = "no_tick";
        public string Execute(FungeContext fungeContext)
        {
            if (fungeContext.CurrentThread.StringMode)
            {
                switch (Name)
                {
                    case '"':
                        RealExecute(fungeContext);
                        fungeContext.CurrentThread.PreviousCommandName = Name;
                        return null;
                    case ' ' when fungeContext.CurrentThread.PreviousCommandName == ' ' && fungeContext.Settings.SgmlSpaces == OptionStatus.Enable:
                        return Notick;
                }

                fungeContext.PushToTopStack(Name);
                fungeContext.CurrentThread.PreviousCommandName = Name;
                return null;
            }
            
            if (!fungeContext.IsSupported(this))
            {
                if (fungeContext.Settings.WarnIfCommandNotSupported == OptionStatus.Enable)
                {
                    return $"{fungeContext.Version} not supporting  {Name} command at " +
                           $"x: {fungeContext.CurrentThread.CurrentPosition.X} " + 
                           $"y: {fungeContext.CurrentThread.CurrentPosition.Y} " + 
                           $"z: {fungeContext.CurrentThread.CurrentPosition.Z} ";
                }

                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                return null;
            }

            var error = RealExecute(fungeContext);
            return CanTick ? error : Notick;
        }
        
        public char Name { get; }

        public bool CanTick => true;

        public string RealExecute(FungeContext fungeContext);
    }
}