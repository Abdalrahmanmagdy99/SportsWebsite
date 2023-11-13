using SprotsWebsite.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace SprotsWebsite.Services.Dtos
{
    public class AddPlayerRequestDto
    {
        [Required]
        public string Name { get; set; }
        [DateInThePast(ErrorMessage = "Not Valid Date")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int TeamId { get; set; }

    }
}
