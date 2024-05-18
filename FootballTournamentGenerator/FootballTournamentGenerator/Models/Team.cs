using System.ComponentModel.DataAnnotations;

namespace FootballTournamentGenerator.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Point { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalDifference { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public TeamDetail TeamDetail { get; set; }




        public List<TournamentTeam> TournamentTeams { get; set; }


    }
}
