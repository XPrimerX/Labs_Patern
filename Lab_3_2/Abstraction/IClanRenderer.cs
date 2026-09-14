namespace Lab_3_2.Abstraction;

public interface IClanRenderer
{
    void RenderHeader(string title);
    void RenderClan(List<IUnit> clan, IUnit? leader);
}