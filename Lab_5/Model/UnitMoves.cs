using Lab_5.Abstraction;
using Lab_5.Enums;

namespace Lab_5.Model;

public class UnitMoves : IMoves
{
    public MovementType MovementType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}