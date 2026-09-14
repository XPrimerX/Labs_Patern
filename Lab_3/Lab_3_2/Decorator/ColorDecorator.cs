using Lab_3_2.Abstraction;
using Lab_3_2.Enums;

namespace Lab_3_2.Decorator;

public class ColorDecorator : UnitDecorator
{
    private readonly Colors _color;

    public ColorDecorator(IUnit unit, Colors? color = null) : base(unit)
    {
        var values = Enum.GetValues<Colors>();
        _color = color ?? values[Random.Shared.Next(values.Length)];
    }

    public override string GetInfo() => $"{base.GetInfo()} | Колір: {TranslateColor(_color),-10}";

    private static string TranslateColor(Colors color) => color switch
    {
        Colors.Red => "Червоний",
        Colors.Blue => "Синій",
        Colors.Green => "Зелений",
        Colors.Black => "Чорний",
        Colors.White => "Білий",
        _ => color.ToString()
    };
}