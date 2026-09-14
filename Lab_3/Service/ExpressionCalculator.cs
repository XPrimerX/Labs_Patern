using System.Globalization;
using Lab_3.Abstraction;
using Lab_3.Enums;

namespace Lab_3.Service;

public class ExpressionCalculator
{
    private readonly ICalculator _calculator;
    private readonly IExpressionParser _parser;

    private static readonly Dictionary<string, Operation> OperationMap = new()
    {
        { "+", Operation.Add },
        { "-", Operation.Subtract },
        { "*", Operation.Multiply },
        { "/", Operation.Divide }
    };


    public ExpressionCalculator(ICalculator calculator, IExpressionParser parser = null)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        _parser = parser ?? new RpnParser(); 
    }

    public double Evaluate(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            throw new ArgumentException("Вираз не може бути порожнім", nameof(expression));

        var rpnTokens = _parser.ToRpn(expression);
        return EvaluateRpn(rpnTokens);
    }

    private double EvaluateRpn(List<string> rpn)
    {
        var stack = new Stack<double>();

        foreach (var token in rpn)
        {
            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
            {
                stack.Push(num);
            }
            else if (OperationMap.TryGetValue(token, out var op))
            {
                if (stack.Count < 2)
                    throw new InvalidOperationException("Некоректний вираз: недостатньо операндів");

                double b = stack.Pop();
                double a = stack.Pop();
                
                double result = _calculator.CalculateTwo(a, b, op);
                stack.Push(result);
            }
            else
            {
                throw new ArgumentException($"Невідомий токен у виразі: {token}");
            }
        }

        if (stack.Count != 1)
            throw new InvalidOperationException("Некоректний математичний вираз");

        return stack.Pop();
    }
}