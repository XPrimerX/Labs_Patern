namespace Lab_6.Abstraction;

public abstract  class UnitFactory
{
    public abstract Units CreateUnit(); 

    
    public Units CreateUnitAt(int x, int y)
    {
        var unit = CreateUnit();
        unit.moves.X = x;
        unit.moves.Y = y;
        return unit;
    }
}