using Lab_3.Abstraction;
using Lab_3.Service;

namespace Lab_3;

class Program
{
    static void Main(string[] args)
    {
        ICalculator fullCalc = new FullCalculator();
        ICalculator lightCalc = new LightCalculator(fullCalc); 

   
        var expressionCalc = new ExpressionCalculator(lightCalc);
        
        string expr1 = "0 + 5 * (10 - 0)"; 
        string expr2 = "(12 + 0) / 4 * 0";

        Console.WriteLine($"{expr1} = {expressionCalc.Evaluate(expr1)}"); 
        Console.WriteLine($"{expr2} = {expressionCalc.Evaluate(expr2)}"); 
    }
}