using Lab_2.Interface;

namespace Lab_2.Services;

public class ParserResolver
{
    private readonly List<ITransactionParserFactory> _factories;

    public ParserResolver(List<ITransactionParserFactory> factories)
    {
        _factories = factories;
    }

    public ITransactionParser Resolve(string extension)
    {
        var factory = _factories.FirstOrDefault(f => f.CanCreate(extension));
        if (factory == null)
            throw new NotSupportedException($"Формат файлу не підтримується: {extension}");

        return factory.CreateParser();
    }
}

