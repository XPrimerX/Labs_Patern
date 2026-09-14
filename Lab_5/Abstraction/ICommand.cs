using Lab_5.Services;

namespace Lab_5.Abstraction;

public interface ICommand
{
    string Name { get; }
    void Execute(BattleUnit unit, Random random);
}