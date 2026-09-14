using Lab_4.Abstraction;
using Lab_4.Enums;

namespace Lab_4.Players;

public class Dwarf:Units
{
    public Dwarf()
    {
        playerClass = PlayerClass.Dwarf;
        weapons = Weapons.Sword;
        moves.MovementType = MovementType.afoot;
    }
}