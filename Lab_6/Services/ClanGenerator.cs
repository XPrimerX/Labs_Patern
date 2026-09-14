using Lab_6.Abstraction;
using Lab_6.Factorys;

namespace Lab_6.Services;

public class ClanGenerator
{
    private readonly Random _random = new();
    private readonly List<UnitFactory> _factories = new()
    {
        new ElfFactory(),
        new DwarfFactory(),
        new GnomeFactory()
    };

    public List<Units> GenerateClan()
    {
        var clan = new List<Units>();

        foreach (var factory in _factories)
        {
        
            var prototype = factory.CreateUnit();

            int count = _random.Next(3, 6); 
            for (int i = 0; i < count; i++)
            {
            
                var unit = prototype.Clone();

                
                unit.moves = factory.CreateUnit().moves;
                unit.moves.X = _random.Next(0, 20);
                unit.moves.Y = _random.Next(0, 20);

                clan.Add(unit);
            }
        }

        return clan;
    }
}