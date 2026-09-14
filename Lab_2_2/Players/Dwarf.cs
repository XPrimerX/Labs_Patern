using Lab_2_2.Abstraction;
using Lab_2_2.Enums;

namespace Lab_2_2.Players;

public class Dwarf:Units
{
    public Dwarf()
    {
        playerClass = PlayerClass.Dwarf;
        weapons = Weapons.Sword;
        moves.MovementType = MovementType.afoot;
    }
}