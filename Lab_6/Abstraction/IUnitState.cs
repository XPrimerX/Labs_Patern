using Lab_6.Services;

namespace Lab_6.Abstraction;

public interface IUnitState
{
    string Name { get; }
    void HandleForward(BattleUnit context, Random random);
    void HandleFight(BattleUnit context, Random random);
    void HandleBack(BattleUnit context);
}