using Lab_2_2.Abstraction;
using Lab_2_2.Enums;

namespace Lab_2_2.Model;

public class UnitMoves : IMoves
{
    public MovementType MovementType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}