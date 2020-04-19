using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.Commands;
using funge_98.Commands.Befunge93Commands;
using funge_98.Commands.Befunge98Commands;

namespace funge_98.FactoriesStuff.Factories
{
    [ContainerElement]
    public class Funge98CommandsFactory : IFactory<Command>
    {
        private readonly List<IFactory<Command>> _otherFactories;

        public Funge98CommandsFactory( ArithmeticCommandFactory af,GoCommandFactory gf, IOCommandsFactory iof, OtherCommandsFactory ocf, PushHexCommandFactory phcf)
        {
            _otherFactories = new List<IFactory<Command>> {gf,iof,ocf, phcf, af };
        }
        public IEnumerable<Command> CreateProducts()
        {
            var cc = new List<Command>
            {
                new NopeCommand(),
                new JumpCommand(),
                new ReflectDirectionCommand(),
                new AbsoluteDeltaCommand(),
                new BeginBlockCommand(),
                new ConditionTurnCommand(),
                new FetchCharacterCommand(),
                new RotateDirectionCommand('['),
                new RotateDirectionCommand(']'),
                new InputFileCommand(),
                new StoreCharacterCommand(),
                new ClearStackCommand(),
                new JumpForward(),
                new GetInfoCommand(),
                new CloseBracketCommand(),
                new OpenBracketCommand()
            };
            cc = _otherFactories.Aggregate(cc, (current, factory) => current.Concat(factory.CreateProducts()).ToList());
            var r = cc.Find(x => x.Name == 'r') as ReflectDirectionCommand;
            for (char c = 'A'; c <= 'Z'; c++)
            {
                cc.Add(new FingerPrint(c,r));
            } 
            cc.Add(new StackUnderStackCommand());
            cc.Add(new EndBlockCommand(r));
            cc.Add(new IterateCommand(cc));
            cc.Add(new SplitCommand(r));
            return cc;
        }
    }
}