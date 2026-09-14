using Lab_3_2.Abstraction;
using Lab_3_2.Enums;

namespace Lab_3_2.Decorator;

public class ClothingDecorator : UnitDecorator
{
    private readonly Equipment _equipment;

    public ClothingDecorator(IUnit unit, Equipment? equipment = null) : base(unit)
    {
        var values = Enum.GetValues<Equipment>();
        _equipment = equipment ?? values[Random.Shared.Next(values.Length)];
    }

    public override string GetInfo() => $"{base.GetInfo()} | Одяг: {TranslateEquipment(_equipment)}";
    private static string TranslateEquipment(Equipment equipment) => equipment switch
    {
        Equipment.LeatherArmor => "Шкіряний обладунок",
        Equipment.Chainmail => "Кольчуга",
        Equipment.Robe => "Мантія",
        Equipment.TravelerCloak => "Плащ мандрівника",
        _ => equipment.ToString()
    };
}