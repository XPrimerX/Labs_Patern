using Lab_5.Abstraction;
using Lab_5.Players;

namespace Lab_5.Factorys;

public class ElfFactory : UnitFactory
{
    public override Units CreateUnit() => new Elf();
}