namespace Lab_6.Services;

public class UnitMemento
{
    public int X { get; }
    public int Y { get; }
    public string State { get; }

    public UnitMemento(int x, int y, string state)
    {
        if (x < 0)
            throw new ArgumentOutOfRangeException(nameof(x), "Координата X не може бути від'ємною.");
        if (y < 0)
            throw new ArgumentOutOfRangeException(nameof(y), "Координата Y не може бути від'ємною.");
        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("Стан повинен бути заповнений.", nameof(state));

        X = x;
        Y = y;
        State = state;
    }
}