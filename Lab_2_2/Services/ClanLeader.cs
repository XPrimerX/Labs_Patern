using Lab_2_2.Abstraction;

namespace Lab_2_2.Services;

public sealed  class ClanLeader
{
    private static ClanLeader? _instance;
    private static readonly object _lock = new();

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