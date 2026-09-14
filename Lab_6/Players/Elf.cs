using Lab_6.Abstraction;
using Lab_6.Enums;

namespace Lab_6.Players;

public class Elf:Units
{
    public Elf()
    {
        playerClass = PlayerClass.Elf;
        weapons = Weapons.Bow;
        moves.MovementType = MovementType.fly;
    }
}