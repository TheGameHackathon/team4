using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly GameManager games;

        public GamesController(GameManager games)
        {
            this.games = games;
        }
        [HttpPost]
        public IActionResult Index([FromQuery] int level)
        {
            var newGuidGame = games.AddGame(level);
            return new ObjectResult(games.GetGameById(newGuidGame));
        }
    }
}
