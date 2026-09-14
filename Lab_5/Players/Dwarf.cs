using Lab_5.Abstraction;
using Lab_5.Enums;

namespace Lab_5.Players;

public class Dwarf:Units
{
    public Dwarf()
    {
        playerClass = PlayerClass.Dwarf;
        weapons = Weapons.Sword;
        moves.MovementType = MovementType.afoot;
    }
}