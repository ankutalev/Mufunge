using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands
{
    public interface ICommand
    {
        public string Execute(FungeContext fungeContext)
        {
            if (fungeContext.StringMode)
            {
                switch (Name)
                {
                    case '"':
                        RealExecute(fungeContext);
                        _prev = Name;
                        fungeContext.Ticks++;
                        return null;
                    case ' ' when _prev == ' ':
                        return null;
                }

                fungeContext.PushToTopStack(Name);
                fungeContext.Ticks++;
                _prev = Name;
                return null;
            }
            
            if (!fungeContext.IsSupported(this))
            {
                if (fungeContext.Settings.WarnIfCommandNotSupported == OptionStatus.Enable)
                {
                    return $"{fungeContext.Version} not supporting  {Name} command";
                }

                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                return null;
            }

            var error = RealExecute(fungeContext);
            if (CanTick)
                fungeContext.Ticks++;
            return error;
        }

        private static int _prev;

        public char Name { get; }

        public bool CanTick => true;

        public string RealExecute(FungeContext fungeContext);
    }
}