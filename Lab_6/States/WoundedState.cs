using Lab_6.Abstraction;
using Lab_6.Services;

namespace Lab_6.States;

public class WoundedState : IUnitState
{
    public string Name => "Поранений";

    public void HandleForward(BattleUnit context, Random random)
    {
        context.Unit.Move(0, -1, 20, 20);
        Console.WriteLine($"{context.Unit.GetInfo()} (поранений) все одно рухається вперед.");
        TryKnockOut(context, random);
    }

    public void HandleFight(BattleUnit context, Random random)
    {
        Console.WriteLine($"{context.Unit.GetInfo()} (поранений) все одно б'ється!");
        TryKnockOut(context, random);
    }

    public void HandleBack(BattleUnit context)
    {
        context.Unit.Move(0, 1, 20, 20);
        Console.WriteLine($"{context.Unit.GetInfo()} відступає назад і відновлюється.");
        context.TransitionTo(new HealthyState());
    }

    private void TryKnockOut(BattleUnit context, Random random)
    {
        if (random.Next(4) == 0) 
        {
            context.TransitionTo(new OutOfBattleState());
        }
    }
}