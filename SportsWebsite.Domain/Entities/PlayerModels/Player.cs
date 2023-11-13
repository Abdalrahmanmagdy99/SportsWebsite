using SprotsWebsite.Domain.Interfaces;

namespace SprotsWebsite.Domain.Entities
{
    public class Player : ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public bool IsDeleted { get; set; }

    }
}
