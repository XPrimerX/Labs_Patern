using System.Data;
using Lab_5.Abstraction;
using Lab_5.Enums;

namespace Lab_5.Services;

public class ClanMediator: IMediator
{
    private IHandler? _chainHead;

    public void SetChain(IHandler chainHead)
    {
        _chainHead = chainHead;
    }

    public void IssueCommand(ICommand command)
    {
        Console.WriteLine($"\n=== Глава клану віддає наказ: {command.Name} ===");
        _chainHead?.Handle(command);
    }


    public void Notify(object sender, string ev)
    {
        Console.WriteLine($"[Медіатор] Подія: {ev}");
    }
}