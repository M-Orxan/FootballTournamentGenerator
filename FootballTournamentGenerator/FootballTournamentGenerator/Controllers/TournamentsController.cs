using FootballTournamentGenerator.DAL;
using FootballTournamentGenerator.Enums;
using FootballTournamentGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace FootballTournamentGenerator.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly AppDbContext _db;
        public TournamentsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Tournament> tournaments = await _db.Tournaments.Include(x=>x.TournamentTeams).ThenInclude(x=>x.Team).ToListAsync();
            return View(tournaments);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Teams = await _db.Teams.ToListAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Tournament newTournament, TournamentFormat format, int[] teamIds)
        {

            ViewBag.Teams = await _db.Teams.ToListAsync();
            bool isExists = await _db.Tournaments.AnyAsync(x => x.Name == newTournament.Name);

            if (isExists)
            {
                ModelState.AddModelError("Name", "A tournament with this name already exists. Please choose another name");
                return View();
            }

            
            


            List<TournamentTeam> tournamentTeams = new List<TournamentTeam>();

            foreach (int teamId in teamIds)
            {
                TournamentTeam tournamentTeam=new TournamentTeam
                {
                    TeamId = teamId
                };

                tournamentTeams.Add(tournamentTeam);

            }

            newTournament.TournamentTeams= tournamentTeams;
            newTournament.NumberOfParticipants = tournamentTeams.Count;
            newTournament.TournamentFormat = format;



            await _db.Tournaments.AddAsync(newTournament);

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {


            Tournament dbTournament = await _db.Tournaments.FirstOrDefaultAsync(x => x.Id == id);

            if (dbTournament == null)
            {
                return View("NotFound");
            }



            _db.Tournaments.Remove(dbTournament);

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
