using Lab_3_2.Abstraction;
using Lab_3_2.Players;

namespace Lab_3_2.Factorys;

public class DwarfFactory: UnitFactory
{
    public override Units CreateUnit() => new Dwarf();
}