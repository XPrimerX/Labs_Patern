using Lab_6.Abstraction;
using Lab_6.Enums;

namespace Lab_6.Players;

public class Dwarf:Units
{
    public Dwarf()
    {
        playerClass = PlayerClass.Dwarf;
        weapons = Weapons.Sword;
        moves.MovementType = MovementType.afoot;
    }
}