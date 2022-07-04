using Microsoft.AspNetCore.Mvc;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/levels/{levelIndex}")]
    public class GamesController : Controller
    {
        private readonly IGamesRepository gameRepository;
        private readonly MapRepository mapRepository;

        public GamesController(IGamesRepository gameRepository, MapRepository mapRepository)
        {
            this.gameRepository = gameRepository;
            this.mapRepository = mapRepository;
        }

        [HttpPost]
        public IActionResult Index(int levelIndex)
        {
            var gameDto = levelIndex == 1 ? TestData.FirstLevel() : TestData.SecondLevel();
            gameRepository.Insert(gameDto);
            mapRepository.Insert(gameDto);
            return Ok(gameDto);
        }
    }
}