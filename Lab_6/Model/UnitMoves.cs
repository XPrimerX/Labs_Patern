using Lab_6.Abstraction;
using Lab_6.Enums;

namespace Lab_6.Model;

public class UnitMoves : IMoves
{
    public MovementType MovementType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}