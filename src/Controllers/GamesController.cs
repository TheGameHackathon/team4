using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;
using thegame.Services.Abstractions;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public IActionResult Index()
        {
           // GameDto newGame = _gameService.CreateNewGame();
            return new ObjectResult(TestData.AGameDto(new Vec(1, 1)));
        }
    }
}
