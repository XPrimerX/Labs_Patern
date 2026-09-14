using Lab_3_2.Enums;
using Lab_3_2.Model;

namespace Lab_3_2.Abstraction;

public abstract class Units: IUnit
{
    public string Name { get; set; } = default!;
    public PlayerClass playerClass;
    public Weapons weapons;
    public IMoves moves = new UnitMoves();

    public int X => moves.X;
    public int Y => moves.Y;

    public virtual char Symbol => GetType().Name switch
    {
        "Elf" => 'E',
        "Dwarf" => 'D',
        "Gnome" => 'G',
        _ => '?'
    };

    public virtual Units Clone()
    {
        var clone = (Units)this.MemberwiseClone();
        clone.moves = new UnitMoves
        {
            MovementType = this.moves.MovementType,
            X = this.moves.X,
            Y = this.moves.Y
        };
        return clone;
    }

    public virtual string GetInfo() =>
        $"{GetType().Name,-8} | Класс: {playerClass} | Зброя: {weapons,-15} | Пересування: {moves.MovementType,-12} | Координати: ({X},{Y})";

    public override string ToString() => GetInfo();
}