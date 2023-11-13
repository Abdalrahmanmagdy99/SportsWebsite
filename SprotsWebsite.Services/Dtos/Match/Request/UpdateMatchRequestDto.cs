using SprotsWebsite.Services.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services.Dtos
{
    public class UpdateMatchRequestDto
    {
        [Required]
        public int MatchId { get; set; }
        public int? HomeTeamId { get; set; }
        public int? AwayTeamId { get; set; }
        public int? TournamentId { get; set; }
    }
}
