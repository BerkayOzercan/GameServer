using GameServer.Database;
using GameServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Services;

public class PlayerService : IPlayerService
{
    private readonly AppDBContext _context;
    private readonly ISortingService _sortingService;

    public PlayerService(AppDBContext context, ISortingService sortingService)
    {
        _context = context;
        _sortingService = sortingService;
    }

    public async Task<List<PlayerModel>> GetAllAsync()
    {
        var players = await _context.Players.ToListAsync();
        return players;
    }

    public async Task<List<PlayerModel>> GetSortedByIdAsync(bool sorted = true)
    {
        var players = await _context.Players.ToListAsync();
        if (sorted)
            players = _sortingService.Sort(players, i => i.Id, ascending: true);
        return players;
    }

    public async Task<List<PlayerModel>> GetSortedByNameAsync(bool sorted = true)
    {
        var players = await _context.Players.ToListAsync();
        if (sorted)
            players = _sortingService.Sort(players, n => n.Name, ascending: true);
        return players;
    }

    public async Task<List<PlayerModel>> GetSortedByScoreAsync(bool sorted = true)
    {
        var players = await _context.Players.ToListAsync();
        if (sorted)
            players = _sortingService.Sort(players, s => s.Score, ascending: false);
        return players;
    }

    public async Task<PlayerModel?> GetPlayerByIdAsync(int id)
    {
        return await _context.Players.FindAsync(id);
    }

    public async Task AddPlayerAsync(PlayerModel player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePlayerAsync(PlayerModel player)
    {
        _context.Update(player);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlayerAsync(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player != null)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}
