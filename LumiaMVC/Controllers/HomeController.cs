using LumiaMVC.Business.Services.Abstract;
using LumiaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LumiaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeamService _teamService;

        public HomeController(ILogger<HomeController> logger,ITeamService teamService)
        {
            _logger = logger;
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            return View(_teamService.GetAllTeams());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
