using Microsoft.EntityFrameworkCore;

namespace FootballTournamentGenerator.DAL
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }



    }
}
