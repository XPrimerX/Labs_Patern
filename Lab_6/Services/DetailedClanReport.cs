
using Lab_6.Abstraction;

namespace Lab_6.Services;

public class DetailedClanReport : ClanReport
{
    public DetailedClanReport(IClanRenderer renderer) : base(renderer) { }

    public override void Show(string title, List<IUnit> clan, IUnit? leader = null)
    {
        base.Show(title, clan, leader);

        if (leader != null)
        {
            Console.WriteLine();
            Console.WriteLine("=== Детальна інформація про главу клану ===");
            Console.WriteLine(leader.GetInfo());
        }
    }
}