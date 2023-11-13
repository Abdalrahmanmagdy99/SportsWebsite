using SprotsWebsite.Domain.Interfaces;

namespace SprotsWebsite.Domain.Entities
{
    public class Tournament : ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoUrl { get; set; }
        public bool IsDeleted { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public List<Team> Teams { get; set; }
        public List<Match> Matches { get; set; }
    }
}
