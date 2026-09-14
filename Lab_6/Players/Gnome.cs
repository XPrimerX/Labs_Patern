using Lab_6.Abstraction;
using Lab_6.Enums;

namespace Lab_6.Players;

public class Gnome:Units
{
    public Gnome()
    {
        playerClass = PlayerClass.Gnome;
        weapons = Weapons.Axe;
        moves.MovementType = MovementType.afoot;
    }
}