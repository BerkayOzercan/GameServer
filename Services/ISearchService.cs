using GameServer.Models;

namespace GameServer.Services;

public interface ISearchService
{
    List<PlayerModel> SearchFromList(List<PlayerModel> players, string search);
}
