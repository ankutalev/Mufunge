using Attributes;

namespace funge_98.Commands.Befunge93Commands.MoveCommand
{
    [ContainerElement, Befunge93]
    public class MoveUp : MoveCommand
    {
        public MoveUp() : base('^')
        {
        }
    }

    [ContainerElement, Befunge93]
    public class MoveDown : MoveCommand
    {
        public MoveDown() : base('v')
        {
        }
    }

    [ContainerElement, Unefunge]
    public class MoveLeft : MoveCommand
    {
        public MoveLeft() : base('<')
        {
        }
    }

    [ContainerElement, Unefunge]
    public class MoveRight : MoveCommand
    {
        public MoveRight() : base('>')
        {
        }
    }
    
    [ContainerElement, Unefunge]
    public class MoveRandom : MoveCommand
    {
        public MoveRandom() : base('?')
        {
        }
    }
    
    [ContainerElement, Trefunge]
    public class MoveHigh : MoveCommand
    {
        public MoveHigh() : base('h')
        {
        }
    }
    
    [ContainerElement, Trefunge]
    public class MoveLow : MoveCommand
    {
        public MoveLow() : base('l')
        {
        }
    }
    
    
}