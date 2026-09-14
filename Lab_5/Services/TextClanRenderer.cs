
using Lab_5.Abstraction;

namespace Lab_5.Services;

public class TextClanRenderer : IClanRenderer
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

    public void RenderBattle(List<BattleUnit> clan, BattleUnit? leader)
    {
        foreach (var unit in clan)
        {
            var mark = ReferenceEquals(unit, leader) ? " [ГЛАВА КЛАНУ]" : "";
            Console.WriteLine($"{unit.Unit.GetInfo()} | Стан: {unit.StateName}{mark}");
        }
    }
}