using Lab_6.Abstraction;
using Lab_6.States;

namespace Lab_6.Services;

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
    public UnitMemento Save()
    {
        return new UnitMemento(Unit.X, Unit.Y, _state.Name);
    }

    public void SetPosition(UnitMemento unitMemento)
    {
        int x = unitMemento.X;
        int y = unitMemento.Y;
    }
    public void Restore(UnitMemento unitMemento)
    {
        // повертаємо значання
        Unit.SetPosition(unitMemento.X, unitMemento.Y);

        _state = unitMemento.State switch
        {
            "Здоровий" => new HealthyState(),
            "Поранений" => new WoundedState(),
            "Вийшов з бою" => new OutOfBattleState(),
            _ => _state
        };
    }
}