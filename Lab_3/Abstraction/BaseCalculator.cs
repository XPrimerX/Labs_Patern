using Lab_3.Enums;

namespace Lab_3.Abstraction;

public abstract class BaseCalculator: ICalculator
{
    public double Calculate(Operation operation, params double[] numbers)
    {
        if (numbers == null || numbers.Length < 2)
            throw new ArgumentException("Потрібно щонайменше два числа");

        double result = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            result = CalculateTwo(result, numbers[i], operation);
        }

        return result;
    }
    
    public abstract double CalculateTwo(double a, double b, Operation operation);
}