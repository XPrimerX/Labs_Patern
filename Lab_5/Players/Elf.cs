using Lab_5.Abstraction;
using Lab_5.Enums;

namespace Lab_5.Players;

public class Elf:Units
{
    public Elf()
    {
        playerClass = PlayerClass.Elf;
        weapons = Weapons.Bow;
        moves.MovementType = MovementType.fly;
    }
}