using Lab_5.Abstraction;
using Lab_5.Services;

namespace Lab_5.Commands;

public class ForwardCommand : ICommand
{
    public string Name => "Вперед";
    public void Execute(BattleUnit unit, Random random) => unit.Forward(random);
}