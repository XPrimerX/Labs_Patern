using Lab_2.Interface;
using Lab_2.Services.Parse_File;

namespace Lab_2.Factory;

public class JsonParserFactory:ITransactionParserFactory
{
    public bool CanCreate(string extension) =>
        extension.Equals(".json", StringComparison.OrdinalIgnoreCase);

    public ITransactionParser CreateParser() => new JsonTransactionParser();
}