using SprotsWebsite.Domain.Entities;

namespace SprotsWebsite.Data.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Tournament> TournamentRepository { get; }
        IRepository<Team> TeamRepository { get; }

        IRepository<Match> MatchRepository { get; }
        IRepository<Image> ImageRepository { get; }
        IRepository<Player> PlayerRepository { get; }
        IRepository<TournamentTeams> TournamentTeamsRepository { get; }

        /// </summary>
        /// <returns>Boolean true if changes were saved to the database, otherwise false.</returns>
        bool SaveChanges();

        /// <summary>
        /// Saves all changes to the database asynchronously.
        /// </summary>
        /// <returns>Boolean true if changes were saved to the database, otherwise false.</returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Disposes of the database context.
        /// </summary>
        void Dispose();
    }
}
