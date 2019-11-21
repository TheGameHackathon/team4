using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using thegame.Infrastructure;

namespace thegame.Controllers
{
    
    public class LevelGetter : Controller
    {
        [HttpPost]
        public int GetLevel(int levelId)
        {
            return levelId;
        }
    }

   
    public class GamesController : Controller
    {
        readonly IMemoryCache cache;
        private static int _levelId;

        public GamesController(IMemoryCache cache) => this.cache = cache;

        [Route("api/games")]
        [HttpPost]
        public IActionResult Index()
        {
            var game = new Game(_levelId);
            cache.Set(game.Id, game);

            return game.ToResponse();
        }

        [Route("api/games/level{levelId}")]
        [HttpPost]
        public int GetLevel(int levelId)
        {
            _levelId = levelId;
            return levelId;

        }
    }
}