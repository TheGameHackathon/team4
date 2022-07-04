using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Models.DTO;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        [HttpPost]
        public IActionResult Index()
        {
            return Ok(TestData.FirstLevel());
        }
    }
}