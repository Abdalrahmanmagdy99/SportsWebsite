using SprotsWebsite.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services
{
    public interface ITournamentService
    {
        Task<bool> AddTournament(AddTournamentRequestDto addTournamentRequestDto);
        Task<bool> UpdateTournamentInformation(UpdateTournamentRequestDto updateTournamentRequestDto);
        Task<bool> SoftDeleteTournamentById(int tournamentId);
        Task<bool> HardDeleteTournamentById(int tournamentId);
        Task<GetTournamentsResponseDto> GetTournamentsList();
        Task<GetTeamsResponseDto> GetTournamentTeamsById(int tournamentId);
        Task<string> GetTournamentNameById(int tournamentId);
        Task<TournamentDetails> GetTournamentDetailsById(int tournamentId);
        Task<bool> RemoveTeamFromTournament(int tournamentId, int teamId);
        Task<bool> AddTeamToTournament(int teamsId, int tournamentId);
    }
}
