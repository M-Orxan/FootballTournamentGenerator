using System.ComponentModel.DataAnnotations.Schema;

namespace FootballTournamentGenerator.Models
{
    public class TeamDetail
    {
        public int Id { get; set; }
        public int TournamentsParticipatedIn { get; set; }
        public int TotalMatchesPlayed { get; set; }
        public int TotalWins { get; set; }
        public int TotalDraws { get; set; }
        public int TotalLoses { get; set; }

        public Team Team { get; set; }
        [ForeignKey("Team")]
        public int TeamId { get; set; }
    }
}
