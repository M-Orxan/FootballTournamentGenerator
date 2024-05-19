using FootballTournamentGenerator.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballTournamentGenerator.DAL
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TournamentTeam> TournamentTeams { get; set; }
        public DbSet<TeamDetail> TeamDetails { get; set; }
       


    }
}
