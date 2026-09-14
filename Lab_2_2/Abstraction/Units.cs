using Lab_2_2.Enums;
using Lab_2_2.Model;

namespace Lab_2_2.Abstraction;

public abstract class Units
{
    public string Name { get; set; } = default!;
    public PlayerClass playerClass;
    public Weapons weapons;
    public IMoves moves = new UnitMoves();

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
    public override string ToString() =>
        $"{GetType().Name,-8} | Класс: {playerClass} | Зброя: {weapons,-15} | Пересування: {moves.MovementType,-12} | Координати: ({moves.X },{moves.Y})";
}