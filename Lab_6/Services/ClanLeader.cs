using Lab_6.Abstraction;
using Lab_6.Enums;

namespace Lab_6.Services;

public sealed  class ClanLeader
{
    private static ClanLeader? _instance;
    private static readonly object _lock = new();

    private ClanMediator? _mediator;

    public Units? Leader { get; private set; }

    private ClanLeader() { }

    public static ClanLeader Instance
    {
        get
        {
            lock (_lock)
            {
                _instance ??= new ClanLeader();
                return _instance;
            }
        }
    }

    public void Elect(Units unit)
    {
        Leader = unit;
    }
    
    public void SetMediator(ClanMediator mediator)
    {
        _mediator = mediator;
    }
    
    public void Order(ICommand command)
    {
        if (_mediator == null)
        {
            Console.WriteLine("Медіатор не встановлено — неможливо віддати наказ.");
            return;
        }

        _mediator.IssueCommand(command);
    }

    public void PrintInfo()
    {
        if (Leader == null)
        {
            Console.WriteLine("Глава клану ще не обраний.");
            return;
        }

        Console.WriteLine("=== Глава клану ===");
        Console.WriteLine(Leader);
    }
}