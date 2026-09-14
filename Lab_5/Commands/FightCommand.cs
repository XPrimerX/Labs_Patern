using Lab_5.Abstraction;
using Lab_5.Services;

namespace Lab_5.Commands;

public class FightCommand : ICommand
{
    public string Name => "До бою";
    public void Execute(BattleUnit unit, Random random) => unit.Fight(random);
}