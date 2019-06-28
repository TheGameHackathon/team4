using System;
using Microsoft.AspNetCore.Mvc;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpPost("start")]
        public IActionResult Start()
        {
            return Ok();
        }


        [HttpPost("{gameId}/card/open")]
        public IActionResult OpenCard(Guid gameId, [FromBody] object cardPosition)
        {
            return Ok();
        }

        [HttpGet("leaderboard")]
        public IActionResult LeaderBoard()
        {
            return Ok();
        }

        [HttpGet("watch/{gameId}")]
        public IActionResult Watch(Guid gameId)
        {
            return Ok();
        }
    }
}