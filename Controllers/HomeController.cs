using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GameServer.Models;
using GameServer.Services;

namespace GameServer.Controllers;

public class HomeController : Controller
{
    private readonly IPlayerService _playerService;
    private readonly ISearchService _searchService;

    public HomeController(IPlayerService playerService, ISearchService searchService)
    {
        _playerService = playerService;
        _searchService = searchService;
    }

    [Route("")]
    [Route("home")]
    public async Task<IActionResult> Index(string search)
    {
        var players = await _playerService.GetAllAsync();

        if (players == null || players.Count == 0)
            ViewData["Message"] = "No players found.";

        players = _searchService.SearchFromList(players, search);
        return View(players);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
