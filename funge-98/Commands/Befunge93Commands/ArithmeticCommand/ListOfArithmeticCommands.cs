using Attributes;

namespace funge_98.Commands.Befunge93Commands.ArithmeticCommand
{
    [UnefungeCommand, ContainerElement]
    public class PlusCommand : ArithmeticCommand
    {
        public PlusCommand() : base((a, b) => a + b, '+')
        {
        }
    }

    [UnefungeCommand, ContainerElement]
    public class MinusCommand : ArithmeticCommand
    {
        public MinusCommand() : base((a, b) => a - b, '-')
        {
        }
    }

    [UnefungeCommand, ContainerElement]
    public class MultiplyCommand : ArithmeticCommand
    {
        public MultiplyCommand() : base((a, b) => a * b, '*')
        {
        }
    }

    [UnefungeCommand, ContainerElement]
    public class DivCommand : ArithmeticCommand
    {
        public DivCommand() : base((a, b) => a / b, '/')
        {
        }
    }

    [UnefungeCommand]
    [ContainerElement]
    public class ModCommand : ArithmeticCommand
    {
        public ModCommand() : base((a, b) => a % b, '%')
        {
        }
    }
}