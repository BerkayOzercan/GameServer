using GameServer.Models;
using Microsoft.EntityFrameworkCore;

namespace GameServer.Database;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

    public DbSet<PlayerModel> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlayerModel>().HasKey(p => p.Id);

        // Mock data
        modelBuilder.Entity<PlayerModel>().HasData(
            new PlayerModel { Id = 1, Name = "Alice", Level = 1, Score = 100 },
            new PlayerModel { Id = 2, Name = "Bob", Level = 1, Score = 85 },
            new PlayerModel { Id = 3, Name = "Charlie", Level = 1, Score = 95 },
            new PlayerModel { Id = 4, Name = "David", Level = 1, Score = 70 },
            new PlayerModel { Id = 5, Name = "Scot", Level = 1, Score = 770 },
            new PlayerModel { Id = 6, Name = "Kirk", Level = 1, Score = 1240 },
            new PlayerModel { Id = 7, Name = "Mark", Level = 1, Score = 876 }
        );
    }
}
