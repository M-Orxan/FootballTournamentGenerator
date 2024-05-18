using FootballTournamentGenerator.DAL;
using FootballTournamentGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballTournamentGenerator.Controllers
{
    public class TeamsController : Controller
    {
        private readonly AppDbContext _db;
        public TeamsController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<Team> teams = await _db.Teams.Include(x => x.TeamDetail).ToListAsync();
            return View(teams);
        }




        //Create

        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Team newTeam)
        {


            bool isExists = await _db.Teams.AnyAsync(x => x.Name == newTeam.Name);

            if (isExists)
            {
                ModelState.AddModelError("Name", "A team with this name already exists. Please choose another name");
                return View();
            }

            newTeam.TeamDetail = new TeamDetail();

            await _db.Teams.AddAsync(newTeam);

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(int id)
        {
           

            Team dbTeam=await _db.Teams.FirstOrDefaultAsync(x => x.Id == id);

            if (dbTeam==null)
            {
                return View("NotFound");
            }

            

             _db.Teams.Remove(dbTeam);

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}
