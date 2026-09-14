namespace Lab_4.Abstraction;

public interface IClanRenderer
{
    void RenderHeader(string title);
    void RenderClan(List<IUnit> clan, IUnit? leader);
}