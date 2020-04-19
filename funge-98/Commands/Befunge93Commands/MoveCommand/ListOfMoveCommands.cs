using Attributes;

namespace funge_98.Commands.Befunge93Commands.MoveCommand
{
    [ContainerElement, Befunge93Command]
    public class MoveUp : MoveCommand
    {
        public MoveUp() : base('^')
        {
        }
    }

    [ContainerElement, Befunge93Command]
    public class MoveDown : MoveCommand
    {
        public MoveDown() : base('v')
        {
        }
    }

    [ContainerElement, UnefungeCommand]
    public class MoveLeft : MoveCommand
    {
        public MoveLeft() : base('<')
        {
        }
    }

    [ContainerElement, UnefungeCommand]
    public class MoveRight : MoveCommand
    {
        public MoveRight() : base('>')
        {
        }
    }
}