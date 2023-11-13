using Microsoft.EntityFrameworkCore;
using SprotsWebsite.Domain.DbContexts;
using SprotsWebsite.Domain.Entities;

namespace SprotsWebsite.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SprotsWebsiteDbContext _context;
        private bool _disposed = false;


        private IRepository<Match> _matchRepository;
        private IRepository<Tournament> _TournamentRepository;
        private IRepository<Team> _teamRepository;
        private IRepository<Image> _ImageRepository;
        private IRepository<Player> _playerRepository;
        private IRepository<TournamentTeams> _tournamentTeamsRepository;


        public UnitOfWork(SprotsWebsiteDbContext context) => _context = context;

        public IRepository<Image> ImageRepository
        {
            get { return _ImageRepository ??= new Repository<Image>(_context); }
        } 
        public IRepository<Player> PlayerRepository
        {
            get { return _playerRepository ??= new Repository<Player>(_context); }
        } 
        public IRepository<TournamentTeams> TournamentTeamsRepository
        {
            get { return _tournamentTeamsRepository ??= new Repository<TournamentTeams>(_context); }
        }
        public IRepository<Match> MatchRepository
        {
            get { return _matchRepository ??= new Repository<Match>(_context); }
        }
        public IRepository<Tournament> TournamentRepository
        {
            get { return _TournamentRepository ??= new Repository<Tournament>(_context); }
        }
        public IRepository<Team> TeamRepository
        {
            get { return _teamRepository ??= new Repository<Team>(_context); }
        }
        ///<inheritdoc/>
        public bool SaveChanges() => _context.SaveChanges() > 0;
        ///<inheritdoc/>
        public async Task<bool> SaveChangesAsync() => (await _context.SaveChangesAsync()) > 0;
        ///<inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    try
                    {
                        _context.Dispose();

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            _disposed = true;
        }

    }
}
