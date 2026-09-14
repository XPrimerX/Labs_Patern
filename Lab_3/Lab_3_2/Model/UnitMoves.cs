using Lab_3_2.Abstraction;
using Lab_3_2.Enums;

namespace Lab_3_2.Model;

public class UnitMoves : IMoves
{
    public MovementType MovementType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}