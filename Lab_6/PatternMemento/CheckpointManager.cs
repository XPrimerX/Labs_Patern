namespace Lab_6.Services;

public class CheckpointManager
{
    private readonly Stack<ClanMemento> _checkpoints = new();

    public void SaveCheckpoint(ClanMemento memento)
    {
        _checkpoints.Push(memento);
    }

    public ClanMemento? Undo()
    {
        if (_checkpoints.Count == 0)
        {
            Console.WriteLine("[Caretaker] Немає збережених контрольних точок.");
            return null;
        }

        return _checkpoints.Pop();
    }

    public int CheckpointsCount => _checkpoints.Count;
}