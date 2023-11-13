using SprotsWebsite.Services.Dtos;
using SprotsWebsite.Services.Validations;
using System.ComponentModel.DataAnnotations;

namespace SportsWebsite.ViewModels
{
    public class AddPlayerViewModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TeamId { get; set; }
        public List<TeamName> Teams { get; set; }
    }
}
