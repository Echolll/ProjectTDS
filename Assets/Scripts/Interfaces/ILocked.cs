public interface ILocked
{
    public bool IsUnlocked { get; }

    public void OpenLock();
}
