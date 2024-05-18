using FootballTournamentGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FootballTournamentGenerator.Controllers
{
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Error()
        {
            return View();
        }
    }
}