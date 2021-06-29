using AutoMapper;
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
        private readonly IMapper mapper;

        public GamesController(IGamesRepo gamesRepo, IMapper mapper)
        {
            this.gamesRepo = gamesRepo;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Index()
        {
            var game = TestData.AGame(new VectorDto(1, 1));

            gamesRepo.AddGame(game);

            var gameDto = mapper.Map<GameDto>(game);

            return Ok(gameDto);
        }
    }
}
