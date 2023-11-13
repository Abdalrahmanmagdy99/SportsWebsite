using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SprotsWebsite.Services.Dtos
{
    public class AddTournamentRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        [Required]
        public IFormFile Logo { get; set; }
        public List<TeamName> Teams { get; set; }
        [Required]
        public List<int> SelectedTeamsIds { get; set; }
    }
}
