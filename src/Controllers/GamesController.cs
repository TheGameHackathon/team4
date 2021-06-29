using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IGamesRepo gamesRepo;

        public GamesController(IGamesRepo gamesRepo)
        {
            this.gamesRepo = gamesRepo;
        }

        [HttpPost]
        public IActionResult Index()
        {
            var game = TestData.AGameDto(new VectorDto(1, 1));

            gamesRepo.AddGame(game);

            return Ok(game);
        }
    }
}
