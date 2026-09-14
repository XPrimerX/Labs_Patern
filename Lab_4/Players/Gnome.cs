using Lab_4.Abstraction;
using Lab_4.Enums;

namespace Lab_4.Players;

public class Gnome:Units
{
    public Gnome()
    {
        playerClass = PlayerClass.Gnome;
        weapons = Weapons.Axe;
        moves.MovementType = MovementType.afoot;
    }
}