using SprotsWebsite.Services.Dtos;
using SprotsWebsite.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace SportsWebsite.ViewModels
{
    public class GetTournamentTeamsViewModel
    {
        public GetTournamentTeamsViewModel()
        {
        }

        public GetTournamentTeamsViewModel(GetTeamsResponseDto teamsDetails,string tournamentName, int tournamentId, List<TeamName> teams)
        {
            Response = teamsDetails;
            TournamentName = tournamentName;
            TournamentId = tournamentId;
            Teams = teams;
        }

        public GetTeamsResponseDto  Response { get; set; }
        public List<TeamName> Teams { get; set; }
        public string TournamentName { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
    }
}
