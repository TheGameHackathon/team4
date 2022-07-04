using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Models.DTO;
using thegame.Models.Entities;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
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
        public IActionResult Index()
        {
            var gameDto = TestData.FirstLevel();
            gameRepository.Insert(gameDto);
            mapRepository.Insert(gameDto);
            return Ok(gameDto);
        }
    }
}