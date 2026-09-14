using Lab_2_2.Abstraction;
using Lab_2_2.Players;

namespace Lab_2_2.Factorys;

public class DwarfFactory: UnitFactory
{
    public override Units CreateUnit() => new Dwarf();
}