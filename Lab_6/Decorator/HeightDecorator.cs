using Lab_6.Abstraction;

namespace Lab_6.Decorator;

public class HeightDecorator : UnitDecorator
{
    private readonly int _heightCm;

    public HeightDecorator(IUnit unit, int? heightCm = null) : base(unit)
    {
        _heightCm = heightCm ?? Random.Shared.Next(140, 200);
    }

    public override string GetInfo() => $"{base.GetInfo()} | Зріст: {_heightCm} см";
}