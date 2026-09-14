namespace Lab_3.Abstraction;

public interface IExpressionParser
{
    List<string> ToRpn(string expression);
}