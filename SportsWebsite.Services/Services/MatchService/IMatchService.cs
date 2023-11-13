using SprotsWebsite.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services
{
    public interface IMatchService
    {
        Task<bool> AddMatch(AddMatchRequestDto addMatchRequestDto);
        Task<bool> UpdateMatchInformation(UpdateMatchRequestDto updateMatchRequestDto);
        Task<bool> SoftDeleteMatchById(int MatchId);
        Task<bool> HardDeleteMatchById(int MatchId);
        Task<GetMatchesResponseDto> GetMatchesList();
        Task<MatchDetails> GetMatchDetailsById(int matchId);
    }
}
