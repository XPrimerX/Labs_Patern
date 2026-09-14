using Lab_2_2.Abstraction;
using Lab_2_2.Enums;

namespace Lab_2_2.Players;

public class Elf:Units
{
    public Elf()
    {
        playerClass = PlayerClass.Elf;
        weapons = Weapons.Bow;
        moves.MovementType = MovementType.fly;
    }
}