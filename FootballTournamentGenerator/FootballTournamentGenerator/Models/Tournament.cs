using FootballTournamentGenerator.Enums;
using System.ComponentModel.DataAnnotations;

namespace FootballTournamentGenerator.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int NumberOfParticipants { get; set; }

      


        public List<TournamentTeam> TournamentTeams { get; set; }

        [Required]

        public TournamentFormat TournamentFormat { get; set; }


    }
}
