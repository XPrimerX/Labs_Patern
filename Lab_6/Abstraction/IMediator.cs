namespace Lab_6.Abstraction;

public interface IMediator
{
    void Notify(object sender, string ev);
}