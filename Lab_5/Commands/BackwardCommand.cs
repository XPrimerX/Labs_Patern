using Lab_5.Abstraction;
using Lab_5.Services;

namespace Lab_5.Commands;

public class BackwardCommand : ICommand
{
    public string Name => "Назад";
    public void Execute(BattleUnit unit, Random random) => unit.Back();
}