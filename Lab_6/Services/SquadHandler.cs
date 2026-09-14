
using System.Data;

using Lab_6.Abstraction;
using Lab_6.Enums;

namespace Lab_6.Services;
public class SquadHandler :AbstractHandler
{
    public string SquadName { get; }
    private readonly List<BattleUnit> _units;
    private readonly IMediator _mediator;
    private readonly Random _random = new();

    public SquadHandler(string squadName, List<BattleUnit> units, IMediator mediator)
    {
        SquadName = squadName;
        _units = units;
        _mediator = mediator;
    }
   
    public override object? Handle(object request)
    {
        if (request is ICommand command)
        {
            Console.WriteLine($"--- Загін «{SquadName}» отримав команду ---");

            foreach (var unit in _units)
            {
                command.Execute(unit, _random);
            }

            _mediator.Notify(this, $"{SquadName} виконав команду {command.GetType().Name}");
        }

        return base.Handle(request);
    }
}