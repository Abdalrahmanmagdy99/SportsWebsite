using SprotsWebsite.Domain.Interfaces;

namespace SprotsWebsite.Domain.Entities
{
    public class Match : ISoftDelete
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int TournamentId { get; set; }
        public bool IsDeleted { get; set; }
        public Tournament Tournament { get; set; }
        public Team AwayTeam { get; set; }
        public Team HomeTeam { get; set; }
    }
}
