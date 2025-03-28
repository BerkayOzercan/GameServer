namespace GameServer.Services;

public class SortingService : ISortingService
{
    public List<T> Sort<T, TKey>(List<T> list, Func<T, TKey> keySelector, bool ascending = true) where TKey : IComparable<TKey>
    {
        if (ascending)
            list.Sort((x, y) => keySelector(x).CompareTo(keySelector(y)));
        else
            list.Sort((x, y) => keySelector(y).CompareTo(keySelector(x)));
        return list;
    }
}
