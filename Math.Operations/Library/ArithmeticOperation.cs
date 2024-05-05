using Woody230.Math.Adaptable;

namespace Woody230.Math.Operations;
public class ArithmeticOperation(ArithmeticOperationType type)
{
    public AdaptableNumber Operate(AdaptableNumber value, AdaptableNumber operand) => type switch
    {
        ArithmeticOperationType.Add => value + operand,
        ArithmeticOperationType.Subtract => value - operand,
        ArithmeticOperationType.Multiply => value * operand,
        ArithmeticOperationType.Divide => value / operand,
        _ => throw new NotImplementedException($"The operation type {type} is not supported."),
    };
}
