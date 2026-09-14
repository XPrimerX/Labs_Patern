using Lab_1.Interface;

namespace Lab_1.Services;

public class ParserResolver
{
    private readonly Dictionary<string, ITransactionParser> _parsers;

    public ParserResolver(Dictionary<string, ITransactionParser> parsers)
    {
        _parsers = parsers;
    }

    public ITransactionParser Resolve(string extension)
    {
        var key = extension.ToLowerInvariant();

        if (!_parsers.TryGetValue(key, out var parser))
            throw new NotSupportedException($"Формат файлу не підтримується: {extension}");

        return parser;
    }
}