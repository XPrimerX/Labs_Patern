namespace Lab_3_2.Abstraction;

public interface  IUnit
{
    string GetInfo();
    int X { get; }
    int Y { get; }
    char Symbol { get; }
}