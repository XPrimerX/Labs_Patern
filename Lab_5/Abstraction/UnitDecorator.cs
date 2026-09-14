namespace Lab_5.Abstraction;

public abstract class UnitDecorator: IUnit
{
    protected readonly IUnit _unit;

    protected UnitDecorator(IUnit unit)
    {
        _unit = unit;
    }
    public IUnit GetInner() => _unit;
    public virtual string GetInfo() => _unit.GetInfo();
    public int X => _unit.X;
    public int Y => _unit.Y;
    public virtual char Symbol => _unit.Symbol;
    public void Move(int dx, int dy, int maxX, int maxY) => _unit.Move(dx, dy, maxX, maxY);
}