using Lab_6.Abstraction;
using Lab_6.Services;

namespace Lab_6.States;

public class HealthyState : IUnitState
{
    public string Name => "Здоровий";

    public void HandleForward(BattleUnit context, Random random)
    {
        context.Unit.Move(0, -1, 20, 20);
        Console.WriteLine($"{context.Unit.GetInfo()} рухається вперед.");
        TryWound(context, random);
    }

    public void HandleFight(BattleUnit context, Random random)
    {
        Console.WriteLine($"{context.Unit.GetInfo()} вступає у бій!");
        TryWound(context, random);
    }

    public void HandleBack(BattleUnit context)
    {
        context.Unit.Move(0, 1, 20, 20);
        Console.WriteLine($"{context.Unit.GetInfo()} відступає назад. (вже здоровий, відновлювати нічого)");
    }

    private void TryWound(BattleUnit context, Random random)
    {
        if (random.Next(4) == 0) // 25% шанс поранення
        {
            context.TransitionTo(new WoundedState());
        }
    }
}