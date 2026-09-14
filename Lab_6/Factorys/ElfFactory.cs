using Lab_6.Abstraction;
using Lab_6.Players;

namespace Lab_6.Factorys;

public class ElfFactory : UnitFactory
{
    public override Units CreateUnit() => new Elf();
}