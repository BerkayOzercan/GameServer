using System;
using GameServer.Models;

namespace GameServer.Services;

public class SearchService : ISearchService
{
    public List<PlayerModel> SearchFromList(List<PlayerModel> players, string search)
    {
        var newPlayers = players;
        if (!string.IsNullOrEmpty(search))
        {
            newPlayers = players.Where(p =>
            p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            p.Score.ToString().Contains(search)).ToList();
        }
        return newPlayers;
    }
}
