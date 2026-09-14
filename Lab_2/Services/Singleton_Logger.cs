namespace Lab_2.Services;

public sealed class Singleton_Logger
{
    private readonly List<string> _logHistory = new();
    private Singleton_Logger()
    {
    }
    public static Singleton_Logger Instance => Nested.instance;

    private class Nested
    {
        static Nested()
        {
        }

        internal static readonly Singleton_Logger instance = new Singleton_Logger();
    }
    public void Log(string message)
    {
        var entry = $"[{DateTime.Now:HH:mm:ss}] {message}";
        _logHistory.Add(entry);
        Console.WriteLine(entry);
    }

    public IReadOnlyList<string> GetHistory() => _logHistory.AsReadOnly();
}