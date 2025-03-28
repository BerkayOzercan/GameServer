using GameServer.Models;
using GameServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameServer.Controllers
{
    [Route("PlayerList")]
    public class PlayerListController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ISearchService _searchService;

        public PlayerListController(IPlayerService playerService, ISearchService searchService)
        {
            _playerService = playerService;
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            var players = await _playerService.GetAllAsync();

            if (players == null)
            {
                ViewData["Message"] = "Player service returned null.";
                return View(new List<PlayerModel>());
            }
            players = _searchService.SearchFromList(players, search);
            return View(players);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlayerModel player)
        {
            if (ModelState.IsValid)
            {
                await _playerService.AddPlayerAsync(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null) return NotFound();
            return View(player);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlayerModel player)
        {
            if (ModelState.IsValid)
            {
                await _playerService.UpdatePlayerAsync(player);
                return RedirectToAction("Index");
            }
            return View(player);
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            if (player == null) return NotFound();
            return View(player);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _playerService.DeletePlayerAsync(id);
            return RedirectToAction("Index");
        }
    }
}
