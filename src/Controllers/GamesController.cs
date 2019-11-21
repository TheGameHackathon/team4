using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using thegame.Infrastructure;

namespace thegame.Controllers
{
    [Route("api/games/level{levelId}")]
    public class LevelGetter : Controller
    {
        [HttpGet]
        public int GetLevel(int levelId)
        {
            return levelId;
        }
    }

    [Route("api/games")]
    public class GamesController : Controller
    {
        readonly IMemoryCache cache;

        public GamesController(IMemoryCache cache) => this.cache = cache;

        [HttpPost]
        public IActionResult Index()
        {
            var game = new Game();
            cache.Set(game.Id, game);

            return game.ToResponse();
        }
        
        [HttpPost("{gameId}")]
        public IActionResult Index(Guid gameId)
        {
            var game = cache.Get<Game>(gameId) ?? new Game(gameId);
            cache.Set(game.Id, game);
            game.OnLevelLoaded();

            return game.ToResponse();
        }
    }
}