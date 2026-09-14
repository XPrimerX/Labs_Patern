namespace Lab_2.Interface;

public interface ITransactionParserFactory
{
    bool CanCreate(string extension);
    ITransactionParser CreateParser();
}