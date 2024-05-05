using Woody230.Math.Adaptable;

namespace Woody230.Math.Operations;
public class NumericOperation(NumericOperationType type)
{
    public AdaptableNumber Operate(AdaptableNumber value, AdaptableNumber operand) => type switch
    {
        NumericOperationType.Add => value + operand,
        NumericOperationType.Subtract => value - operand,
        NumericOperationType.Multiply => value * operand,
        NumericOperationType.Divide => value / operand,
        _ => throw new NotImplementedException($"The operation type {type} is not supported."),
    };
}
