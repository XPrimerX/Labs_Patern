using Lab_4.Abstraction;
using Lab_4.Players;

namespace Lab_4.Factorys;

public class GnomeFactory:UnitFactory
{
    public override Units CreateUnit() => new Gnome();
}