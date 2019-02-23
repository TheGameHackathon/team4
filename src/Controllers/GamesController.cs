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
        private readonly IScoreRepository scores;

        public GamesController(IGameRepository games,IScoreRepository scores)
        {
            this.games = games;
            this.scores = scores;
        }
        
        [HttpGet("leaderboard")]
        public IActionResult LeaderBoard()
        {
            return Ok(scores.GetBest(10));
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

        [HttpPost("{gameID}/finish/{login}")]
        public IActionResult FinishGame([FromRoute] Guid gameID, [FromRoute] string login)
        {
            var state = games.FindById(gameID).State;
            scores.Insert(new ScoreEntry {UserLogin = login, Fails = state.Fails, Score = state.Score});
            return Ok();
        }
    }
}
    