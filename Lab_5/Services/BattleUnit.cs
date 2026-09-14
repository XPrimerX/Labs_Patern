using Lab_5.Abstraction;
using Lab_5.States;

namespace Lab_5.Services;

public class BattleUnit
{
    
    public IUnit Unit { get; }
    private IUnitState _state;

    public string StateName => _state.Name;
    public bool CanAct => _state is not OutOfBattleState;

    public BattleUnit(IUnit unit)
    {
        Unit = unit;
        _state = new HealthyState();
    }

    public void TransitionTo(IUnitState state)
    {
        _state = state;
        Console.WriteLine($"{Unit.GetInfo()} тепер у стані: {state.Name}");
    }

    public void Forward(Random random) => _state.HandleForward(this, random);
    public void Fight(Random random) => _state.HandleFight(this, random);
    public void Back() => _state.HandleBack(this);
}