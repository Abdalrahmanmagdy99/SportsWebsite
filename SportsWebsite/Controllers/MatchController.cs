using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SprotsWebsite.Services;
using SprotsWebsite.Services.Dtos;

namespace SportsWebsite.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService MatchService )
        {
            _matchService = MatchService;
        }
        [Authorize]
        public async Task<IActionResult> AddMatch(AddMatchRequestDto addMatchRequestDto)
        {
            if (addMatchRequestDto is null || !ModelState.IsValid) return BadRequest();
            var IsAdded = await _matchService.AddMatch(addMatchRequestDto);
            if (!IsAdded) return Conflict();
            return Ok();
        }
        [Authorize]
        public async Task<IActionResult> UpdateMatchInformation(UpdateMatchRequestDto updateMatchRequestDto)
        {
            if (updateMatchRequestDto is null || !ModelState.IsValid) return BadRequest();
            var IsUpdated = await _matchService.UpdateMatchInformation(updateMatchRequestDto);
            if (!IsUpdated) return Conflict();
            return Ok();
        }
        [Authorize]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            if (id < 1) return BadRequest();
            var IsDeleted = await _matchService.SoftDeleteMatchById(id);
            if (!IsDeleted) return Conflict();
            return Ok();
        }
        public async Task<IActionResult> GetMatchesList()
        { 
            var matches = await _matchService.GetMatchesList();


            return Ok();
        }
    }
}
