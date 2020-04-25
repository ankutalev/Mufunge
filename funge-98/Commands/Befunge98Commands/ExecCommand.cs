using System.Diagnostics;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class ExecCommand : ICommand
    {
        public char Name { get; } = '=';
        public string RealExecute(FungeContext fungeContext)
        {
            var name = fungeContext.PopString();
            var process = Process.Start(name);
            if (process == null)
            {
                fungeContext.PushToTopStack(-1);
                return $" Can't start {name}";
            }
            process.WaitForExit();
            fungeContext.PushToTopStack(process.ExitCode);
            return null;
        }
    }
}