using System.ComponentModel.DataAnnotations;

namespace FootballTournamentGenerator.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        

        public List<TournamentTeam> TournamentTeams { get; set; }


    }
}
