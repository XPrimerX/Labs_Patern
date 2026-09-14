using Lab_3_2.Abstraction;
using Lab_3_2.Players;

namespace Lab_3_2.Factorys;

public class ElfFactory : UnitFactory
{
    public override Units CreateUnit() => new Elf();
}