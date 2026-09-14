namespace Lab_6.Services;

public class ClanOriginator
{
    private readonly List<BattleUnit> _clan;

    public ClanOriginator(List<BattleUnit> clan)
    {
        _clan = clan;
    }

    public ClanMemento CreateCheckpoint(string label)
    {
        var snapshots = _clan.ToDictionary(unit => unit, unit => unit.Save());
        Console.WriteLine($"[Memento] Контрольну точку «{label}» створено ({snapshots.Count} юнітів).");
        return new ClanMemento(snapshots, label);
    }

    public void RestoreCheckpoint(ClanMemento memento)
    {
        foreach (var (unit, snapshot) in memento.Snapshots)
        {
            unit.Restore(snapshot);
        }
        Console.WriteLine($"[Memento] Клан відновлено до контрольної точки «{memento.Label}» ({memento.CreatedAt:HH:mm:ss}).");
    }
}