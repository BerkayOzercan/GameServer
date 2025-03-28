namespace GameServer.Services;

public interface ISortingService
{
    List<T> Sort<T, TKey>(List<T> list, Func<T, TKey> keySelector, bool ascending = true)
            where TKey : IComparable<TKey>;
}
