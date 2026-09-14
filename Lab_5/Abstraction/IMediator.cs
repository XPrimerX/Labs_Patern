namespace Lab_5.Abstraction;

public interface IMediator
{
    void Notify(object sender, string ev);
}