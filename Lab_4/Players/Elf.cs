using Lab_4.Abstraction;
using Lab_4.Enums;

namespace Lab_4.Players;

public class Elf:Units
{
    public Elf()
    {
        playerClass = PlayerClass.Elf;
        weapons = Weapons.Bow;
        moves.MovementType = MovementType.fly;
    }
}