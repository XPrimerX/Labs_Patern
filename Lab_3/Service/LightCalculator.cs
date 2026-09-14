using Lab_3.Abstraction;
using Lab_3.Enums;

namespace Lab_3.Service;

public class LightCalculator : BaseCalculator
{
    private readonly ICalculator _fullCalculator;

    private const double Epsilon = 1e-9;
    private static bool IsZero(double x) => Math.Abs(x) < Epsilon;

    public LightCalculator(ICalculator fullCalculator)
    {
        _fullCalculator = fullCalculator ?? throw new ArgumentNullException(nameof(fullCalculator));
    }

    public override double CalculateTwo(double a, double b, Operation operation)
    {
        switch (operation)
        {
            case Operation.Add:
                if (IsZero(a)) return b;
                if (IsZero(b)) return a;
                break;

            case Operation.Subtract:
                if (IsZero(b)) return a;
                if (IsZero(a)) return -b;
                break;

            case Operation.Multiply:
                if (IsZero(a) || IsZero(b)) return 0;
                break;

            case Operation.Divide:
                if (IsZero(b)) throw new DivideByZeroException("Ділення на нуль неможливе");
                if (IsZero(a)) return 0;
                break;

            default:
                throw new ArgumentException("Невідома операція");
        }

        return _fullCalculator.CalculateTwo(a, b, operation);
    }
}