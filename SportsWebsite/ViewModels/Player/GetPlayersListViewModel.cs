using SprotsWebsite.Services.Dtos;

namespace SportsWebsite.ViewModels
{
    public class GetPlayersListViewModel
    {
        public GetPlayersListViewModel()
        {
        }

        public GetPlayersListViewModel(GetPlayersResponseDto response, List<TeamName> teams)
        {
            Response = response;
            Teams = teams;
        }

        public GetPlayersResponseDto  Response { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TeamId { get; set; }
        public List<TeamName> Teams { get; set; }
    }
}
