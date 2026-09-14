using Lab_6.Enums;

namespace Lab_6.Abstraction;

public interface IMoves
{
    public MovementType MovementType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}