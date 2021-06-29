using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using AutoMapper;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using thegame.GameObjects;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private readonly IGamesRepo gamesRepo;
        private readonly IMapper mapper;

        public MovesController(IGamesRepo gamesRepo, IMapper mapper)
        {
            this.gamesRepo = gamesRepo;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
        {
            var game = gamesRepo.GetGameById(gameId);
            var playerPosition = GetCellPlayer(game);
            var newPosition = new VectorDto(playerPosition.Pos.X, playerPosition.Pos.Y);

            if (game.MonitorMouseClicks && userInput.ClickedPos != null)
            {
                foreach (var neighbor in GetNeighborsPoints(playerPosition.Pos))
                {
                    if (EqualsVectorsDto(neighbor, userInput.ClickedPos) && CanMoveTo(game, userInput.ClickedPos))
                    {
                        newPosition = userInput.ClickedPos;
                        break;
                    }
                }
            }

            if (game.MonitorKeyboard)
            {
                var deltaMove = GetDeltaMove(userInput.KeyPressed);
                var newPos = new VectorDto(playerPosition.Pos.X + deltaMove.X, playerPosition.Pos.Y + deltaMove.Y);
                if (CanMoveTo(game, newPos))
                {
                    newPosition = newPos;
                }
            }

            var newGame = MovePlayer(game, newPosition);
            gamesRepo.AddGame(newGame);

            var gameDto = mapper.Map<GameDto>(newGame);
            
            return Ok(gameDto);
        }

        
        private static ICell GetCellPlayer(Game game)
        {
            foreach (var cell in game.Cells)
            {
                if (cell.Type == CellType.Player)
                {
                    return cell;
                }
            }

            throw new ArgumentException("Не был найден игрок на поле");
        }

        private static bool CanMoveTo(Game game, VectorDto to)
        {
            foreach (var cell in game.Cells)
            {
                if (EqualsVectorsDto(cell.Pos, to))
                {
                    return cell.Type != CellType.Wall;
                }
            }

            return true;
        }

        private static IEnumerable<VectorDto> GetNeighborsPoints(VectorDto vector)
        {
            yield return new VectorDto(vector.X - 1, vector.Y);
            yield return new VectorDto(vector.X, vector.Y - 1);
            yield return new VectorDto(vector.X + 1, vector.Y);
            yield return new VectorDto(vector.X, vector.Y + 1);
        }

        private static bool EqualsVectorsDto(VectorDto v1, VectorDto v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        private static VectorDto GetDeltaMove(int keyPressed)
        {
            return keyPressed switch
            {
                87 => new VectorDto(0, -1),
                65 => new VectorDto(-1, 0),
                83 => new VectorDto(0, 1),
                68 => new VectorDto(1, 0),
                _ => new VectorDto(0, 0)
            };
        }

        private static Game MovePlayer(Game game, VectorDto newPosition)
        {
            var newCells = new List<ICell>();
            foreach (var cell in game.Cells)
            {
                if (cell.Type == CellType.Player)
                {
                    newCells.Add(new Cell(cell.Id, newPosition, CellType.Player, cell.Content, cell.ZIndex));
                }
                else
                {
                    newCells.Add(cell);
                }
            }

            return new Game(newCells.ToArray(), game.MonitorKeyboard, game.MonitorMouseClicks, new Size(game.Width, game.Height), game.Id, game.IsFinished, game.Score);
        }
    }
    
    
}