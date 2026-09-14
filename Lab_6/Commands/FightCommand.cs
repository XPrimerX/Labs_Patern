using Lab_6.Abstraction;
using Lab_6.Services;

namespace Lab_6.Commands;

public class FightCommand : ICommand
{
    public string Name => "До бою";
    public void Execute(BattleUnit unit, Random random) => unit.Fight(random);
}