using SprotsWebsite.Domain.Interfaces;
using System.Security.Principal;

namespace SprotsWebsite.Domain.Entities
{
    public class TournamentTeams : ISoftDelete
    {
        public TournamentTeams()
        {
        }

        public TournamentTeams(int teamId, int tournamentId)
        {
            TeamId = teamId;
            TournamentId = tournamentId;
        }
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int TournamentId { get; set; }
        public bool IsDeleted { get; set; }
        public Tournament Tournament { get; set; }
        public Team Team { get; set; }

    }
}
