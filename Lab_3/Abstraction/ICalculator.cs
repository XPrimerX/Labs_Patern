using Lab_3.Enums;

namespace Lab_3.Abstraction;

public interface ICalculator
{
    double Calculate(Operation operation, params double[] numbers);
    double CalculateTwo(double a, double b, Operation operation);
}

