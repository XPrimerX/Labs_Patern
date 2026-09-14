using Lab_3_2.Abstraction;
using Lab_3_2.Enums;

namespace Lab_3_2.Players;

public class Elf:Units
{
    public Elf()
    {
        playerClass = PlayerClass.Elf;
        weapons = Weapons.Bow;
        moves.MovementType = MovementType.fly;
    }
}