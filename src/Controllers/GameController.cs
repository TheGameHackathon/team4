using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Models.Dto;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpPost("start")]
        public ActionResult<GameStateDto> Start([FromBody] StartGameDto startGameDto)
        {
            return Ok();
        }


        [HttpPost("{gameId}/card/open")]
        public ActionResult<GameStateDto> OpenCard(Guid gameId, [FromBody] PointDto cardPosition)
        {
            return Ok();
        }

        [HttpGet("leaderboard")]
        public ActionResult<LeaderBoardRowDto> LeaderBoard()
        {
            return Ok();
        }

        [HttpGet("watch/{gameId}")]
        public ActionResult<GameStateDto> Watch(Guid gameId)
        {
            return Ok();
        }
    }
}