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

        public GamesController(IGamesRepository gameRepository) => this.gameRepository = gameRepository;

        [HttpPost]
        public IActionResult Index()
        {
            var gameDto = TestData.FirstLevel();
            gameDto.Cells[6].Type = "player";
            gameRepository.Insert(gameDto);
            return Ok(gameDto);
        }
    }
}