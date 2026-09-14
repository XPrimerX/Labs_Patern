using Lab_3_2.Abstraction;

namespace Lab_3_2.Services;

public class TextClanRenderer: IClanRenderer
{
    public void RenderHeader(string title) => Console.WriteLine($"=== {title} ===");

    public void RenderClan(List<IUnit> clan, IUnit? leader)
    {
        foreach (var unit in clan)
        {
            var mark = ReferenceEquals(unit, leader) ? " [ГЛАВА КЛАНУ]" : "";
            Console.WriteLine(unit.GetInfo() + mark);
        }
    }
}