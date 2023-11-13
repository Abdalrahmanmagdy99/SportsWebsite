using Microsoft.EntityFrameworkCore;
using SprotsWebsite.Data.Repository;
using SprotsWebsite.Domain.Entities;
using SprotsWebsite.Services.Dtos;
using SprotsWebsite.Services.Validations;

namespace SprotsWebsite.Services
{
    public class MatchService : IMatchService
    {

        private readonly IUnitOfWork _unitOfWork;

        public MatchService( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddMatch(AddMatchRequestDto addMatchRequestDto)
        {
            Match Match = new Match
            {
                AwayTeamId = addMatchRequestDto.AwayTeamId,
                HomeTeamId = addMatchRequestDto.HomeTeamId,
                TournamentId = addMatchRequestDto.TournamentId
            };
            await _unitOfWork.MatchRepository.InsertAsync(Match);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> HardDeleteMatchById(int MatchId)
        {
            Match Match = await _unitOfWork.MatchRepository.GetByIdAsync(MatchId);
            _unitOfWork.MatchRepository.HardDelete(Match);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> SoftDeleteMatchById(int MatchId)
        {
            Match Match = await _unitOfWork.MatchRepository.GetByIdAsync(MatchId);
            _unitOfWork.MatchRepository.Delete(Match);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateMatchInformation(UpdateMatchRequestDto updateMatchRequestDto)
        {
            Match Match = await _unitOfWork.MatchRepository.GetAsIQueryable()
                .FirstOrDefaultAsync(x => x.Id == updateMatchRequestDto.MatchId);

            if (Match == null) return false;

            if (IdValidations.IsIdValidForUpdate(updateMatchRequestDto.TournamentId))
                Match.TournamentId = (int)updateMatchRequestDto.TournamentId;  

            if (IdValidations.IsIdValidForUpdate(updateMatchRequestDto.HomeTeamId))
                Match.HomeTeamId = (int)updateMatchRequestDto.HomeTeamId;  

            if (IdValidations.IsIdValidForUpdate(updateMatchRequestDto.AwayTeamId))
                Match.TournamentId = (int)updateMatchRequestDto.TournamentId;

            return await _unitOfWork.SaveChangesAsync();
        }
        public async Task<GetMatchesResponseDto> GetMatchesList()
        {
            var matches = await _unitOfWork.MatchRepository.GetWithNoTracking()
                .Select(s => new MatchDetails
                {
                   AwayTeamName = s.AwayTeam.Name,
                   HomeTeamName = s.HomeTeam.Name,
                   MatchId = s.Id,
                   TournamentName = s.Tournament.Name
                }).ToListAsync();
            return new GetMatchesResponseDto(matches);
        }
        public async Task<MatchDetails> GetMatchDetailsById(int matchId)
        {
         
            var matchDetails = await _unitOfWork.MatchRepository.GetWithNoTracking()
                .Where(x=>x.Id== matchId)
                .Select(s => new MatchDetails
                {
                    AwayTeamName = s.AwayTeam.Name,
                    HomeTeamName = s.HomeTeam.Name,
                    MatchId = s.Id,
                    TournamentName = s.Tournament.Name
                }).FirstOrDefaultAsync();
            return matchDetails;
        }
    }
}
