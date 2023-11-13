using SprotsWebsite.Services.Dtos;
using SprotsWebsite.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace SportsWebsite.ViewModels
{
    public class GetTeamsViewModel
    {
        public GetTeamsViewModel()
        {
        }

        public GetTeamsViewModel(GetTeamsResponseDto teamsDetails)
        {
            Response = teamsDetails;
        }

        public GetTeamsResponseDto  Response { get; set; }
    }
}
