using Lab_5.Abstraction;
using Lab_5.Enums;

namespace Lab_5.Players;

public class Gnome:Units
{
    public Gnome()
    {
        playerClass = PlayerClass.Gnome;
        weapons = Weapons.Axe;
        moves.MovementType = MovementType.afoot;
    }
}