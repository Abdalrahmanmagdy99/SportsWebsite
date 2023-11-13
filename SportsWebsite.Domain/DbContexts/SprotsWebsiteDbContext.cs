
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SprotsWebsite.Domain.Entities;

namespace SprotsWebsite.Domain.DbContexts
{
    public class SprotsWebsiteDbContext : IdentityDbContext<User>
    {
        public SprotsWebsiteDbContext(DbContextOptions<SprotsWebsiteDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<Match>().HasCheckConstraint("CK_Match_HomeTeamId_AwayTeamId", "HomeTeamId <> AwayTeamId");

            modelBuilder.Entity<Tournament>()
                .HasMany(s => s.Teams)
                .WithMany(x => x.Tournaments)
                .UsingEntity<TournamentTeams>();



            GlobalQueryFilters.CreateGlobalIsDeletedQueryFilter(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<TournamentTeams> TournamentsTeams { get; set; }
    }
}