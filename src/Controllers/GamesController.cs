using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using thegame.Model;

namespace thegame.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private IGameRepository  games;

        public GamesController(IGameRepository games)
        {
            this.games = games;
        }
        
        [HttpGet("leaderboard")]
        public IActionResult LeaderBoard()
        {
            return Ok(50);
        }

        [HttpPost]
        public IActionResult CreateGame()
        {
            //games[lastGameIndex] = new Game();
            ;
            
            //todo: DB
            return Ok(games.Insert(new Game()).Id);
            //return Created( new {id = lastGameIndex},lastGameIndex);
        }
        
        [HttpPost("{gameID}/tiles/{tileID}", Name="RevertTile")]
        public IActionResult RevertTile([FromRoute] Guid gameID, [FromRoute] int tileID)
        {
            var state = games.FindById(gameID).RevertTile(tileID);
            return Ok(state);
        }
    }
}
