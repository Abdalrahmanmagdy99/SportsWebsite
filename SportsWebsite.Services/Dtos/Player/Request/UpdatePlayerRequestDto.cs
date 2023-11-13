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
    public class UpdatePlayerRequestDto
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        [DateInThePast(ErrorMessage = "Not Valid Date.")]
        public DateTime? DateOfBirth { get; set; }
        public int? TeamId { get; set; } 
    }
}
