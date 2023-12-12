using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UGamer.Models;
using UGamer.Services;

namespace UGamer.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IGamesService _gamesService;

        public HomeController(IGamesService gamesService)
        {
			_gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gamesService.GetAll();

            return View(games);

			//sending games from db using igamesService to deal with db
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}