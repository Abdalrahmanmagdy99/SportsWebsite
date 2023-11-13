using Microsoft.AspNetCore.Http;
using SprotsWebsite.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace SprotsWebsite.Services.Dtos
{
    public class UpdateTeamRequestDto
    {
        [Required]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Url]
        public string WebsiteURL { get; set; }
        [DateInThePast(ErrorMessage = "Not Valid Date")]
        public DateTime FoundationDate { get; set; }
        public IFormFile Logo { get; set; }
    }
}
