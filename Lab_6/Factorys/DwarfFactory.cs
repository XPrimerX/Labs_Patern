using Lab_6.Abstraction;
using Lab_6.Players;

namespace Lab_6.Factorys;

public class DwarfFactory: UnitFactory
{
    public override Units CreateUnit() => new Dwarf();
}