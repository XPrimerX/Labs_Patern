using Lab_6.Services;

namespace Lab_6.Abstraction;

public interface ICommand
{
    string Name { get; }
    void Execute(BattleUnit unit, Random random);
}