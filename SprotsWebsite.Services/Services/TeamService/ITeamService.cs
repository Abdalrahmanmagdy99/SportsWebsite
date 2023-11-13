using SprotsWebsite.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services
{
    public interface ITeamService
    {
        Task<bool> AddTeam(AddTeamRequestDto addTeamRequestDto);
        Task<bool> UpdateTeamInformation(UpdateTeamRequestDto updateTeamRequestDto);
        Task<bool> SoftDeleteTeamById(int teamId);
        Task<bool> HardDeleteTeamById(int teamId);
        Task<TeamDetails> GetTeamDetailsById(int teamId);
        Task<GetTeamsResponseDto> GetTeamsList();
        Task<List<TeamName>> GetTeamsDropDownInfo();
        Task<GetPlayersResponseDto> GetTeamPlayersList(int teamId);
        Task<GetTeamsResponseDto> GetLastAddedTeams(int numberOfTeams);

    }
}
