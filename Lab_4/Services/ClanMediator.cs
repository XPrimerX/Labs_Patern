using System.Data;
using Lab_4.Abstraction;
using Lab_4.Enums;

namespace Lab_4.Services;

public class ClanMediator: IMediator
{
    private IHandler? _chainHead;

    public void SetChain(IHandler chainHead)
    {
        _chainHead = chainHead;
    }
    private static string Translate(Commands_Leader command) => command switch
    {
        Commands_Leader.forward => "вперед",
        Commands_Leader.backward=> "назад",
        Commands_Leader.fight => "битися",
        _ => command.ToString()
    };
    public void IssueCommand(Commands_Leader command)
    {
        Console.WriteLine($"\n=== Глава клану віддає наказ: {Translate(command)} ===");
        _chainHead?.Handle(command);
    }


    public void Notify(object sender, string ev)
    {
        Console.WriteLine($"[Медіатор] Подія: {ev}");
    }
}