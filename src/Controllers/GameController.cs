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
            gameEntity.Login = startGameDto.UserName;
            _gameDatabase.Insert(gameEntity);
            var answerDto = new GameStateDto();
            answerDto.Field = new FieldStateDto();
            answerDto.GameId = gameEntity.Id;
            answerDto.UserName = gameEntity.Login;
            return Ok(answerDto);
        }


        [HttpPost("{gameId}/card/open")]
        public ActionResult<GameStateDto> OpenCard(Guid gameId, [FromBody] PointDto cardPosition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var gameEntity = _gameDatabase.FindById(gameId);

            if (!TryOpenCard(gameEntity, cardPosition))
            {
                return BadRequest();
            }

            var openedCardEntities = gameEntity.Cards
                .Where(c => c.Status == CardStatus.Open)
                .ToList();

            CheckOpenedCards(openedCardEntities, gameEntity);

            var swappedPointsDto = GetSwappedCardsDto(gameEntity);

            var openedCardsDto = GetOpenedCardsDto(openedCardEntities);

            var solvedCardEntities = GetSolvedCardsDto(gameEntity);

            var gameStateDto = new GameStateDto()
            {
                GameId = gameEntity.Id,
                UserName = gameEntity.Login,
                Field = new FieldStateDto()
                {
                    Solved = solvedCardEntities,
                    Swapped = swappedPointsDto,
                    Opened = openedCardsDto
                }
            };

            gameEntity.CurrentTurn++;

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

        private bool TryOpenCard(GameEntity gameEntity, PointDto cardPosition)
        {
            try
            {
                var cardEntity =
                    gameEntity.Cards.First(c => c.Position.X == cardPosition.X &&
                                                c.Position.Y == cardPosition.Y);

                if (cardEntity.Status != CardStatus.NotSolved)
                    return false;

                cardEntity.Status = CardStatus.Open;
                _gameDatabase.Insert(gameEntity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void CheckOpenedCards(List<CardEntity> openedCardEntities, GameEntity gameEntity)
        {
            if (openedCardEntities.Count == 2)
            {
                if (openedCardEntities[0].Id == openedCardEntities[1].Id)
                {
                    openedCardEntities.ForEach(c => c.Status = CardStatus.Solved);
                }
                else
                {
                    openedCardEntities.ForEach(c => c.Status = CardStatus.NotSolved);
                    gameEntity.Fails++;
                }
            }
        }

        private List<PointDto> GetSolvedCardsDto(GameEntity gameEntity)
        {
            return gameEntity.Cards
                .Where(c => c.Status == CardStatus.Solved)
                .Select(c =>
                    new PointDto()
                    {
                        X = c.Position.X,
                        Y = c.Position.Y
                    })
                .ToList();
        }

        private List<CardDto> GetOpenedCardsDto(List<CardEntity> openedCardEntities)
        {
            return openedCardEntities
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
        }

        private List<PointDto> GetSwappedCardsDto(GameEntity gameEntity)
        {
            var swappedPointsDto = new List<PointDto>();

            if (gameEntity.CurrentTurn == 3)
            {
                var coordsToChoose = gameEntity.Cards.Where(x => x.Status == CardStatus.NotSolved).ToList();
                var point1 = coordsToChoose[new Random().Next(coordsToChoose.Count)];
                coordsToChoose.Remove(point1);
                var point2 = coordsToChoose[new Random().Next(coordsToChoose.Count)];
                coordsToChoose.Remove(point2);

                var buffer = point1.Position;
                point1.Position = point2.Position;
                point1.Position = buffer;

                swappedPointsDto.Add(new PointDto() {X = point1.Position.X, Y = point1.Position.Y});
                swappedPointsDto.Add(new PointDto() {X = point2.Position.X, Y = point2.Position.Y});

                gameEntity.CurrentTurn = 0;
            }

            return swappedPointsDto;
        }
    }
}