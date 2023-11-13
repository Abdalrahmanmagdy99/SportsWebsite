using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SprotsWebsite.Services;
using SprotsWebsite.Services.Dtos;

namespace SportsWebsite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }
        [HttpGet("GetTournamentDetailsById")]
        public async Task<TournamentDetails> GetTournamentDetailsById(int id) => await _tournamentService.GetTournamentDetailsById(id);
    }
}
