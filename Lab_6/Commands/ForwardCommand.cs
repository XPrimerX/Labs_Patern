using Lab_6.Abstraction;
using Lab_6.Services;

namespace Lab_6.Commands;

public class ForwardCommand : ICommand
{
    public string Name => "Вперед";
    public void Execute(BattleUnit unit, Random random) => unit.Forward(random);
}