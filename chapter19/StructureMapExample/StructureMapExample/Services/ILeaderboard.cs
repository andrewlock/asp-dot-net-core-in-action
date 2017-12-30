namespace StructureMapExample
{
    public interface ILeaderboard<T>
    {
        int GetPosition(object user);
    }
}
