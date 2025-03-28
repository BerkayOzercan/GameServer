using System;
using GameServer.Models;

namespace GameServer.Services;

public interface IPlayerService
{
    Task<List<PlayerModel>> GetAllAsync();
    Task<List<PlayerModel>> GetSortedByIdAsync(bool sorted = true);
    Task<List<PlayerModel>> GetSortedByNameAsync(bool sorted = true);
    Task<List<PlayerModel>> GetSortedByScoreAsync(bool sorted = true);
    Task<PlayerModel?> GetPlayerByIdAsync(int id);
    Task AddPlayerAsync(PlayerModel player);
    Task UpdatePlayerAsync(PlayerModel player);
    Task DeletePlayerAsync(int id);
}
