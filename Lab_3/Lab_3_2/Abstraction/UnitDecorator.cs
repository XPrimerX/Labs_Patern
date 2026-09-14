namespace Lab_3_2.Abstraction;

public abstract class UnitDecorator: IUnit
{
    protected readonly IUnit _unit;

    protected UnitDecorator(IUnit unit)
    {
        _unit = unit;
    }

    public virtual string GetInfo() => _unit.GetInfo();
    public int X => _unit.X;
    public int Y => _unit.Y;
    public virtual char Symbol => _unit.Symbol;
}