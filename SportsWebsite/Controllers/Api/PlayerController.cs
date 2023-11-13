using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SprotsWebsite.Services;
using SprotsWebsite.Services.Dtos;

namespace SportsWebsite.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _PlayerService;

        public PlayerController(IPlayerService PlayerService)
        {
            _PlayerService = PlayerService;
        }
        [HttpGet("GetPlayerDetailsById")]
        public async Task<PlayerDetails> GetPlayerDetailsById(int id) => await _PlayerService.GetPlayerDetailsById(id);

    }
}
