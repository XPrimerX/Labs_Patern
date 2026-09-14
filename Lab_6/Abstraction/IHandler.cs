namespace Lab_6.Abstraction;

public interface IHandler
{
    IHandler SetNext(IHandler handler);
        
    object Handle(object request);
}