using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        [HttpPost]
        public IActionResult Index([FromQuery] int level)
        {
            return new ObjectResult(TestData.AGameDto(level, new Vec(1, 1)));
        }
    }
}
