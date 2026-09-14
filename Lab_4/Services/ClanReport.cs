
using Lab_4.Abstraction;

namespace Lab_4.Services;

public class ClanReport
{
    protected readonly IClanRenderer _renderer;

    public ClanReport(IClanRenderer renderer)
    {
        _renderer = renderer;
    }

    public virtual void Show(string title, List<IUnit> clan, IUnit? leader = null)
    {
        _renderer.RenderHeader(title);
        _renderer.RenderClan(clan, leader);
    }
}