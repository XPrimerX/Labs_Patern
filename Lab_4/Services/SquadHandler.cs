
using System.Data;
using Lab_4.Abstraction;
using Lab_4.Enums;

namespace Lab_4.Services;

public class SquadHandler : AbstractHandler
{
    public string SquadName { get; }
    private readonly List<IUnit> _units;
    private readonly IMediator _mediator;
    private const int BoardWidth = 20;
    private const int BoardHeight = 20;
    public SquadHandler(string squadName, List<IUnit> units, IMediator mediator)
    {
        SquadName = squadName;
        _units = units;
        _mediator = mediator;
    }

    public override object? Handle(object request)
    {
        if (request is Commands_Leader command)
        {
            ExecuteCommand(command);

            // повідомляємо медіатора, що загін виконав команду
            _mediator.Notify(this, $"{SquadName} виконав команду {command}");
        }
        
        return base.Handle(request);
    }

    private void ExecuteCommand(Commands_Leader command)
    {
        Console.WriteLine($"--- Загін «{SquadName}» отримав команду: {command} ---");

        foreach (var unit in _units)
        {
            switch (command)
            {
                case Commands_Leader.forward:
                    unit.Move(0, -1, BoardWidth, BoardHeight); 
                    Console.WriteLine($"{unit.GetInfo()} рухається вперед.");
                    break;

                case Commands_Leader.backward:
                    unit.Move(0, 1, BoardWidth, BoardHeight); 
                    Console.WriteLine($"{unit.GetInfo()} відступає назад.");
                    break;

                case Commands_Leader.fight:
                    Console.WriteLine($"{unit.GetInfo()} вступає у бій!");
                    break;
            }
        }
    }
}