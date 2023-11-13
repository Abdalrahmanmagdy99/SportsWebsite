using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsWebsite.ViewModels;
using SprotsWebsite.Services;
using SprotsWebsite.Services.Dtos;

namespace SportsWebsite.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;

        public PlayerController(IPlayerService PlayerService, ITeamService teamService)
        {
            _playerService = PlayerService;
            _teamService = teamService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddPlayer()
        {
            AddPlayerViewModel addPlayerViewModel = new AddPlayerViewModel
            {
                Teams = await _teamService.GetTeamsDropDownInfo(),
            };
            return View("AddPlayer", addPlayerViewModel);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPlayer(AddPlayerRequestDto addPlayerRequestDto)
        {
            if (addPlayerRequestDto is null || !ModelState.IsValid) return View("AddPlayer");
            var IsAdded = await _playerService.AddPlayer(addPlayerRequestDto);
            if (!IsAdded) return Conflict();
            return RedirectToAction("GetPlayersList");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdatePlayerInformation(UpdatePlayerRequestDto updatePlayerRequestDto)
        {
            if (updatePlayerRequestDto is null || !ModelState.IsValid) return BadRequest();
            var IsUpdated = await _playerService.UpdatePlayerInformation(updatePlayerRequestDto);
            if (!IsUpdated) return Conflict();
            return RedirectToAction("GetPlayersList");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (id < 1) return BadRequest();
            var IsDeleted = await _playerService.SoftDeletePlayerById(id);
            if (!IsDeleted) return Conflict();
            return RedirectToAction("GetPlayersList");
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayersList()
        {
            var players = await _playerService.GetPlayersList();
            var teamsDropDownDetails = await _teamService.GetTeamsDropDownInfo();
            GetPlayersListViewModel getPlayersListViewModel = new GetPlayersListViewModel(players,teamsDropDownDetails);
            return View("GetPlayersList", getPlayersListViewModel);
        }

    }
}
