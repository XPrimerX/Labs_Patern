using System.Globalization;
using System.Text.RegularExpressions;
using Lab_3.Abstraction;

namespace Lab_3.Service;

public class RpnParser : IExpressionParser
{
    private static readonly Dictionary<string, int> PrecedenceMap = new()
    {
        { "+", 1 },
        { "-", 1 },
        { "*", 2 },
        { "/", 2 }
    };
    
    //алгоритм Shunting-yard
    //Це класичний алгоритм сортувальної станції Дейкстри — перетворює звичайний
    //інфіксний вираз ("2 + 3 * 4") у зворотний польський запис (RPN, "2 3 4 * +"), де
    //операції йдуть після операндів.
    public List<string> ToRpn(string expression)
    {
        var tokens = Tokenize(expression);
        var output = new List<string>();
        var opStack = new Stack<string>();

        foreach (var token in tokens)
        {
            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                output.Add(token);
            }
            else if (token == "(")
            {
                opStack.Push(token);
            }
            else if (token == ")")
            {
                while (opStack.Count > 0 && opStack.Peek() != "(")
                    output.Add(opStack.Pop());

                if (opStack.Count > 0)
                    opStack.Pop(); 
            }
            else if (PrecedenceMap.ContainsKey(token))
            {
                while (opStack.Count > 0 && 
                       PrecedenceMap.TryGetValue(opStack.Peek(), out int topPrec) && 
                       topPrec >= PrecedenceMap[token])
                {
                    output.Add(opStack.Pop());
                }
                opStack.Push(token);
            }
        }

        while (opStack.Count > 0)
            output.Add(opStack.Pop());

        return output;
    }

    private IEnumerable<string> Tokenize(string expression)
    {
        var pattern = @"\d+(\.\d+)?|[+\-*/()]";
        var matches = Regex.Matches(expression.Replace(" ", ""), pattern);

        foreach (Match match in matches)
        {
            yield return match.Value;
        }
    }
}