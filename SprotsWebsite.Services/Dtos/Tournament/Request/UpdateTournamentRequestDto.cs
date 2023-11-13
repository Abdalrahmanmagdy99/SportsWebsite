using Microsoft.AspNetCore.Http;
using SprotsWebsite.Services.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services.Dtos
{
    public class UpdateTournamentRequestDto
    {
        [Required]
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public IFormFile Logo { get; set; }
    }
}
