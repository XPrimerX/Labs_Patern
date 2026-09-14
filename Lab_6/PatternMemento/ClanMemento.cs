namespace Lab_6.Services;

public class ClanMemento
{
    public DateTime CreatedAt { get; }
    public string Label { get; }
    private readonly Dictionary<BattleUnit, UnitMemento> _snapshots;
    internal IReadOnlyDictionary<BattleUnit, UnitMemento> Snapshots => _snapshots;

    public ClanMemento(Dictionary<BattleUnit, UnitMemento> snapshots, string label)
    {
        if (string.IsNullOrWhiteSpace(label))
            throw new ArgumentException("Назва знімка повинна бути заповнена.", nameof(label));
        ArgumentNullException.ThrowIfNull(snapshots, nameof(snapshots));
        if (snapshots.Count == 0)
            throw new ArgumentException("Словник знімків не може бути порожнім.", nameof(snapshots));
        Label = label;
        CreatedAt = DateTime.UtcNow;
        _snapshots = new Dictionary<BattleUnit, UnitMemento>(snapshots);
    }
}