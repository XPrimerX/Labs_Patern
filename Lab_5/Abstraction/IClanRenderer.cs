using Lab_5.Services;

namespace Lab_5.Abstraction;

public interface IClanRenderer
{
    void RenderHeader(string title);
    void RenderClan(List<IUnit> clan, IUnit? leader);
    void RenderBattle(List<BattleUnit> clan, BattleUnit? leader);
}