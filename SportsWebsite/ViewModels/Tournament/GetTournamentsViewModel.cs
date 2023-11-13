using SprotsWebsite.Services.Dtos;
using SprotsWebsite.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace SportsWebsite.ViewModels
{
    public class GetTournamentsViewModel
    {
        public GetTournamentsViewModel()
        {
        }

        public GetTournamentsViewModel(GetTournamentsResponseDto tournamentsDetails)
        {
            Response = tournamentsDetails;
        }

        public GetTournamentsResponseDto  Response { get; set; }
    }
}
