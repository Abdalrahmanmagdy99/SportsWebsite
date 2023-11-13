using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SprotsWebsite.Services;
using SprotsWebsite.Services.Dtos;

namespace SportsWebsite.API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpGet("GetTeamDetailsById")]
        public async Task<TeamDetails> GetTeamDetailsById(int id) => await _teamService.GetTeamDetailsById(id);
        [HttpGet("LastAddedTeams")]
        public async Task<GetTeamsResponseDto> LastAddedTeams(int numberOfTeams) => await _teamService.GetLastAddedTeams(numberOfTeams);

    }
}
