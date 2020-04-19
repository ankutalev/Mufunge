using System.Linq;
using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class GetInfoCommand : Command
    {
        public override char Name { get; } = 'y';
        protected override string RealExecute(FungeContext fungeContext)
        {
            var value = fungeContext.GetTopStackTopValues(1)[0];
            var values = Enumerable.Repeat(0, 20).ToArray();
            values[1] = sizeof(int);
            values[5] = '\n';
            values[6] = 2;
            if (value > 0)
            {
                if (value > values.Length)
                    return null;
                fungeContext.PushToTopStack(values[value-1]);
            }
            else
            {
                foreach (var i in values.Reverse())
                {
                    fungeContext.PushToTopStack(i);
                }
            }
                return null;
        }

        private int GetFlagsInfo(CustomSettings settings)
        {
            int info = 0;
            if (settings.IsConcurrent == OptionStatus.Enable)
            {
                info |= 1;
            }

            return info;
        }
    }
}