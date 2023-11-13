using System.ComponentModel.DataAnnotations;

namespace SprotsWebsite.Services.Dtos
{
    public class AddMatchRequestDto
    {
        [Required]
        public int HomeTeamId { get; set; }
        [Required]
        public int AwayTeamId { get; set; }
        [Required]
        public int TournamentId { get; set; }

    }
}
