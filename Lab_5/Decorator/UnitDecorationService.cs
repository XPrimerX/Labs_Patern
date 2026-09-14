
using Lab_5.Abstraction;

namespace Lab_5.Decorator;

public static class UnitDecorationService
{
    public static List<IUnit> ApplyRandomDecorations(List<Units> clan)
    {
        var result = new List<IUnit>();

        foreach (var unit in clan)
        {
            IUnit decorated = unit;

            if (Random.Shared.Next(2) == 0) decorated = new ColorDecorator(decorated);
            if (Random.Shared.Next(2) == 0) decorated = new HeightDecorator(decorated);
            if (Random.Shared.Next(2) == 0) decorated = new ClothingDecorator(decorated);

            result.Add(decorated);
        }

        return result;
    }
}