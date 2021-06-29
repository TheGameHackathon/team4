using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private readonly IGamesRepo gamesRepo;

        public MovesController(IGamesRepo gamesRepo)
        {
            this.gamesRepo = gamesRepo;
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
            
            return Ok(newGame);
        }

        
        private static CellDto GetCellPlayer(GameDto gameDto)
        {
            foreach (var cell in gameDto.Cells)
            {
                if (cell.Type == CellType.Player.ToString())
                {
                    return cell;
                }
            }

            throw new ArgumentException("Не был найден игрок на поле");
        }

        private static bool CanMoveTo(GameDto game, VectorDto to)
        {
            foreach (var cell in game.Cells)
            {
                if (EqualsVectorsDto(cell.Pos, to))
                {
                    return cell.Type != CellType.Wall.ToString();
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

        private static GameDto MovePlayer(GameDto game, VectorDto newPosition)
        {
            var newCells = new List<CellDto>();
            foreach (var cell in game.Cells)
            {
                if (cell.Type == CellType.Player.ToString())
                {
                    newCells.Add(new CellDto(cell.Id, newPosition, CellType.Player, cell.Content, cell.ZIndex));
                }
                else
                {
                    newCells.Add(cell);
                }
            }

            return new GameDto(newCells.ToArray(), game.MonitorKeyboard, game.MonitorMouseClicks, new Size(game.Width, game.Height), game.Id, game.IsFinished, game.Score);
        }
    }
    
    
}