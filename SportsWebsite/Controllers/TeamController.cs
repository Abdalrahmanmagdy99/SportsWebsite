using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsWebsite.ViewModels;
using SprotsWebsite.Services;
using SprotsWebsite.Services.Dtos;

namespace SportsWebsite.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
       
        public TeamController(ITeamService teamService )
        {
            _teamService = teamService;
        } 
        [Authorize]
        public  IActionResult AddTeam()
        {
            return View("AddTeam");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTeam(AddTeamRequestDto addTeamRequestDto)
        {
            if (addTeamRequestDto is null || !ModelState.IsValid) return View("AddTeam");
            var IsAdded = await _teamService.AddTeam(addTeamRequestDto);
            if (!IsAdded) return Conflict();
            return RedirectToAction("GetTeamsList");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateTeamInformation(UpdateTeamRequestDto updateTeamRequestDto)
        {
            if (updateTeamRequestDto is null || !ModelState.IsValid) return BadRequest();
            var IsUpdated = await _teamService.UpdateTeamInformation(updateTeamRequestDto);
            if (!IsUpdated) return Conflict();
            return RedirectToAction("GetTeamsList");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (id < 1) return BadRequest();
            var IsDeleted = await _teamService.SoftDeleteTeamById(id);
            if (!IsDeleted) return Conflict();
            return RedirectToAction("GetTeamsList");
        }
        [HttpGet]
        public async Task<IActionResult> GetTeamsList()
        {
            var teams = await _teamService.GetTeamsList();

            GetTeamsViewModel getTeamsViewModel = new GetTeamsViewModel(teams);
            return View("GetTeamsList", getTeamsViewModel);
        } 
        [HttpGet]
        public async Task<IActionResult> GetTeamPlayersById(int id)
        {
            var players = await _teamService.GetTeamPlayersList(id);

            if (players.PlayersDetails == null) players.PlayersDetails = new List<PlayerDetails>();

            return Ok();
        }
    }
}
