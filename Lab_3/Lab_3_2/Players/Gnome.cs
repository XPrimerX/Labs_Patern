using Lab_3_2.Abstraction;
using Lab_3_2.Enums;

namespace Lab_3_2.Players;

public class Gnome:Units
{
    public Gnome()
    {
        playerClass = PlayerClass.Gnome;
        weapons = Weapons.Axe;
        moves.MovementType = MovementType.afoot;
    }
}