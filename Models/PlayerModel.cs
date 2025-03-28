using System;

namespace GameServer.Models;

public class PlayerModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; }
    public int Score { get; set; }
}
