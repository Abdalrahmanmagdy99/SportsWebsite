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
    public class AddTeamRequestDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Url]
        public string WebsiteURL { get; set; }
        [Required]
        [DateInThePast(ErrorMessage = "Not Valid Date")]
        public DateTime FoundationDate { get; set; }
        public IFormFile Logo { get; set; }
    }
}
