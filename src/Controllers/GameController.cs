using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using thegame.DB;
using thegame.Entity;
using thegame.Generator;
using thegame.Models.Dto;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        private readonly IGameDatabase _gameDatabase;
        private readonly FieldGenerator _generator;

        public GameController(IGameDatabase gameDatabase, FieldGenerator generator)
        {
            _gameDatabase = gameDatabase;
            _generator = generator;
        }

        [HttpPost("start")]
        public ActionResult<GameStateDto> Start([FromBody] StartGameDto startGameDto)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var field = _generator.GenerateField(8, 4);
            var gameEntity = new GameEntity(field);
            _gameDatabase.Insert(gameEntity);
            var answerDto = new GameStateDto();
            answerDto.Field = new FieldStateDto();
            return Ok(answerDto);
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