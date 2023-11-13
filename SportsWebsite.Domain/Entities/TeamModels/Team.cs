using SprotsWebsite.Domain.Interfaces;

namespace SprotsWebsite.Domain.Entities
{
    public class Team : ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteURL { get; set; }
        public DateTime FoundationDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Player> Players { get; set; }
        public bool IsDeleted { get; set; }
    }
}
