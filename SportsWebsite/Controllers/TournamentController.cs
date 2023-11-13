using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsWebsite.ViewModels;
using SprotsWebsite.Services;
using SprotsWebsite.Services.Dtos;

namespace SportsWebsite.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentService _tournamentService;
        private readonly ITeamService _teamService;

        public TournamentController(ITournamentService TournamentService,ITeamService teamService)
        {
            _tournamentService = TournamentService;
            _teamService = teamService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddTournament()
        {
            AddTournamentRequestDto addTournamentRequest = new AddTournamentRequestDto
            {
                Teams = await _teamService.GetTeamsDropDownInfo()
            };
            return View("AddTournament", addTournamentRequest);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTournament(AddTournamentRequestDto addTournamentRequestDto)
        {
            if (addTournamentRequestDto is null || !ModelState.IsValid) return View("AddTournament");
            var IsAdded = await _tournamentService.AddTournament(addTournamentRequestDto);
            if (!IsAdded) return Conflict();
            return RedirectToAction("GetTournamentsList");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateTournamentInformation(UpdateTournamentRequestDto updateTournamentRequestDto)
        {
            if (updateTournamentRequestDto is null || !ModelState.IsValid) return BadRequest();
            var IsUpdated = await _tournamentService.UpdateTournamentInformation(updateTournamentRequestDto);
            if (!IsUpdated) return Conflict();
            return RedirectToAction("GetTournamentsList");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            if (id < 1) return BadRequest();
            var IsDeleted = await _tournamentService.SoftDeleteTournamentById(id);
            if (!IsDeleted) return Conflict();
            return RedirectToAction("GetTournamentsList");
        }
        [HttpGet]
        public async Task<IActionResult> GetTournamentsList()
        {
            var tournaments = await _tournamentService.GetTournamentsList();
            GetTournamentsViewModel getTournamentsViewModel = new GetTournamentsViewModel(tournaments);
            return View("GetTournamentsList", getTournamentsViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> GetTournamentTeams(int id)
        {
            var tournamentTeams = await _tournamentService.GetTournamentTeamsById(id);
            string tournamentName = await _tournamentService.GetTournamentNameById(id);
            var teamsDropDownDetails = await _teamService.GetTeamsDropDownInfo();
            GetTournamentTeamsViewModel getTournamentTeamsViewModel = new GetTournamentTeamsViewModel(tournamentTeams, tournamentName,id, teamsDropDownDetails);
            return View("GetTournamentTeams", getTournamentTeamsViewModel);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> RemoveTeamFromTournament(int tournamentId,int teamId)
        {
            var IsRemoved = await _tournamentService.RemoveTeamFromTournament(tournamentId, teamId);
            if (!IsRemoved) return Conflict();
            return RedirectToAction("GetTournamentTeams", new {id = tournamentId });
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTeamToTournament(int tournamentId,int teamId)
        {
            var IsAdded = await _tournamentService.AddTeamToTournament(teamId, tournamentId);
            if (!IsAdded) return Conflict();
            return RedirectToAction("GetTournamentTeams", new {id = tournamentId });
        }
    }
}
