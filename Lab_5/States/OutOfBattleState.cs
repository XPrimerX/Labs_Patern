using Lab_5.Abstraction;
using Lab_5.Services;

namespace Lab_5.States;

public class OutOfBattleState : IUnitState
{
    public string Name => "Вийшов з бою";

    public void HandleForward(BattleUnit context, Random random)
    {
        Console.WriteLine($"{context.Unit.GetInfo()} вийшов з бою — не може рухатись.");
    }

    public void HandleFight(BattleUnit context, Random random)
    {
        Console.WriteLine($"{context.Unit.GetInfo()} вийшов з бою — не може битись.");
    }

    public void HandleBack(BattleUnit context)
    {
        Console.WriteLine($"{context.Unit.GetInfo()} вийшов з бою — команда 'назад' на нього не діє.");
    }
}