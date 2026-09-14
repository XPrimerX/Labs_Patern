namespace Lab_6.Abstraction;

public interface  IUnit
{
    string GetInfo();
    int X { get; }
    int Y { get; }
    char Symbol { get; }
    void Move(int dx, int dy, int maxX, int maxY);
    void SetPosition(int x, int y);
}