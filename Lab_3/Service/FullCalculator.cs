using Lab_3.Abstraction;
using Lab_3.Enums;

namespace Lab_3.Service;

public class FullCalculator: BaseCalculator
{
    public override double CalculateTwo(double a, double b, Operation operation)
    {
        return operation switch
        {
            Operation.Add => a + b,
            Operation.Subtract => a - b,
            Operation.Multiply => a * b,
            Operation.Divide => b != 0 
                ? a / b 
                : throw new DivideByZeroException("Ділення на нуль неможливе"),
            _ => throw new ArgumentException("Невідома операція")
        };
    }
}