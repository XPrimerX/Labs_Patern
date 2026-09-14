using Lab_3_2.Abstraction;
using Lab_3_2.Enums;

namespace Lab_3_2.Players;

public class Dwarf:Units
{
    public Dwarf()
    {
        playerClass = PlayerClass.Dwarf;
        weapons = Weapons.Sword;
        moves.MovementType = MovementType.afoot;
    }
}