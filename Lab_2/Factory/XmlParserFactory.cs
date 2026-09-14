
using Lab_2.Interface;
using Lab_2.Services.Parse_File;

namespace Lab_2.Factory;

public class XmlParserFactory:ITransactionParserFactory
{
    public bool CanCreate(string extension) =>
        extension.Equals(".xml", StringComparison.OrdinalIgnoreCase);

    public ITransactionParser CreateParser() => new XmlTransactionParser();
}