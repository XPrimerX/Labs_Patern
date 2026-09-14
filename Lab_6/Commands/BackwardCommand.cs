using Lab_6.Abstraction;
using Lab_6.Services;

namespace Lab_6.Commands;

public class BackwardCommand : ICommand
{
    public string Name => "Назад";
    public void Execute(BattleUnit unit, Random random) => unit.Back();
}