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
        
        [HttpPost("level/{level}")]
        public IActionResult Index(int level)
        {
            var game = new Game(level);
            cache.Set(game.Id, game);

            return game.ToResponse();
        }
        
        [HttpPost("{gameId}")]
        public IActionResult Index(Guid gameId)
        {
            var game = cache.Get<Game>(gameId) ?? new Game(gameId);
            cache.Set(game.Id, game);

            return game.ToResponse();
        }
    }
}