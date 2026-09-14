using Lab_4.Abstraction;
using Lab_4.Enums;

namespace Lab_4.Model;

public class UnitMoves : IMoves
{
    public MovementType MovementType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}