namespace Lab_4.Abstraction;

public interface IMediator
{
    void Notify(object sender, string ev);
}