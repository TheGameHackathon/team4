using System;
using System.Collections.Generic;
using System.Linq;
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
            var gameEntity = new GameEntity();
            gameEntity.Cards = field;
            gameEntity.Id = Guid.NewGuid();
            _gameDatabase.Insert(gameEntity);
            var answerDto = new GameStateDto();
            answerDto.Field = new FieldStateDto();
            answerDto.GameId = gameEntity.Id;
            answerDto.UserName = startGameDto.UserName;
            return Ok(answerDto);
        }


        [HttpPost("{gameId}/card/open")]
        public ActionResult<GameStateDto> OpenCard(Guid gameId, [FromBody] PointDto cardPosition)
        {
            var gameEntity = _gameDatabase.FindById(gameId);

            try
            {
                var cardEntity =
                    gameEntity.Cards.First(c => c.Position.X == cardPosition.X &&
                                                c.Position.Y == cardPosition.Y);
                if (cardEntity.Status == CardStatus.NotSolved)
                {
                    cardEntity.Status = CardStatus.Open;
                    _gameDatabase.Insert(gameEntity);
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            var openedCardEntities = gameEntity.Cards
                .Where(c => c.Status == CardStatus.Open)
                .ToList();

            if (openedCardEntities.Count == 2)
            {
                if (openedCardEntities[0].Id == openedCardEntities[1].Id)
                {
                    openedCardEntities.ForEach(c => c.Status = CardStatus.Solved);
                }
                else
                {
                    openedCardEntities.ForEach(c => c.Status = CardStatus.NotSolved);
                }

                openedCardEntities.Clear();
            }

            var openedCardsDto = openedCardEntities
                .Select(c =>
                    new CardDto()
                    {
                        ImageUrl = $"Pictures/{c.Id}.jpg",
                        Position = new PointDto()
                        {
                            X = c.Position.X,
                            Y = c.Position.Y
                        }
                    })
                .ToList();

            var solvedCardEntities = gameEntity.Cards
                .Where(c => c.Status == CardStatus.Solved)
                .Select(c =>
                    new PointDto()
                    {
                        X = c.Position.X,
                        Y = c.Position.Y
                    })
                .ToList();

            var gameStateDto = new GameStateDto()
            {
                GameId = gameEntity.Id,
                UserName = "",
                Field = new FieldStateDto()
                {
                    Solved = solvedCardEntities,
                    Swapped = new List<PointDto>()
                    {
                    },
                    Opened = openedCardsDto
                }
            };

            return Ok(gameStateDto);
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