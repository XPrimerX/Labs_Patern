using Lab_6.Enums;
using Lab_6.Model;

namespace Lab_6.Abstraction;

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
    public void Move(int dx, int dy, int maxX, int maxY)
    {
        moves.X = Math.Clamp(moves.X + dx, 0, maxX - 1);
        moves.Y = Math.Clamp(moves.Y + dy, 0, maxY - 1);
    }
    public virtual string GetInfo() =>
        $"{GetType().Name,-8} | Класс: {playerClass} | Зброя: {weapons,-15} | Пересування: {moves.MovementType,-12} | Координати: ({X},{Y})";
    public void SetPosition(int x, int y)
    {
        moves.X = x;
        moves.Y = y;
    }
    public override string ToString() => GetInfo();
}