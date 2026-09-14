using Lab_5.Enums;

namespace Lab_5.Abstraction;

public interface IMoves
{
    public MovementType MovementType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}