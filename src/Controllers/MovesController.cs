using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoMapper;
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
            var deltaMove = new VectorDto(0, 0);

            if (game.MonitorKeyboard)
            {
                deltaMove = GetDeltaMove(userInput.KeyPressed);
            } 
            else if (game.MonitorMouseClicks && userInput.ClickedPos != null)
            {
                foreach (var neighbor in GetNeighborsPoints(playerPosition.Pos))
                {
                    if (EqualsVectorsDto(neighbor, userInput.ClickedPos))
                    {
                        deltaMove = new VectorDto(userInput.ClickedPos.X - playerPosition.Pos.X, userInput.ClickedPos.Y - playerPosition.Pos.Y);
                        break;
                    }
                }
            }

            var newGame = MovePlayer(game, playerPosition.Pos, deltaMove);
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

        private static ICell GetCell(Game game, VectorDto position)
        {
            return game.Cells.FirstOrDefault(cell => EqualsVectorsDto(cell.Pos, position));
        }

        private static bool CanMoveFromTo(Game game, VectorDto from, VectorDto delta)
        {
            var nextCell = GetCell(game, new VectorDto(from.X + delta.X, from.Y + delta.Y));
            if (nextCell == null)
                return true;
            
            switch (nextCell.Type)
            {
                case CellType.Wall or CellType.BoxOnTarget:
                    return false;
                case CellType.Box:
                {
                    var doubleNextCell = GetCell(game, new VectorDto(@from.X + delta.X * 2, @from.Y + delta.Y * 2));
                    if (doubleNextCell is {Type: CellType.Wall or CellType.Box})
                        return false;
                    break;
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
            switch (keyPressed)
            {
                case 87:
                case 38:
                    return new VectorDto(0, -1);
                case 65:
                case 37:
                    return new VectorDto(-1, 0);
                case 83:
                case 40:
                    return new VectorDto(0, 1);
                case 68:
                case 39:
                    return new VectorDto(1, 0);
                default:
                    return new VectorDto(0, 0);
            }
        }

        private static Game MovePlayer(Game game, VectorDto playerPosition, VectorDto delta)
        {
            if (!CanMoveFromTo(game, playerPosition, delta))
            {
                return game;
            }
            
            var newPlayerPos = new VectorDto(playerPosition.X + delta.X, playerPosition.Y + delta.Y);
            
            var newCells = new List<ICell>();
            foreach (var cell in game.Cells)
            {
                if (cell.Type == CellType.Player)
                {
                    newCells.Add(new Cell(cell.Id, newPlayerPos, CellType.Player, cell.Content, cell.ZIndex));
                }
                else if (EqualsVectorsDto(newPlayerPos, cell.Pos))
                {
                    if (cell.Type == CellType.Box)
                    {
                        var nextBoxPosition = new VectorDto(cell.Pos.X + delta.X, cell.Pos.Y + delta.Y);
                        var nextBoxCell = GetCell(game, nextBoxPosition);
                        if (nextBoxCell is {Type: CellType.Target})
                        {
                            newCells.Add(new Cell(cell.Id, nextBoxPosition, CellType.BoxOnTarget, cell.Content, cell.ZIndex));
                            game.Score++;
                        }
                        else
                        {
                            newCells.Add(new Cell(cell.Id, nextBoxPosition, cell.Type, cell.Content, cell.ZIndex));
                        }
                    }
                    else
                    {
                        newCells.Add(cell);
                    }
                }
                else
                {
                    newCells.Add(cell);
                }
            }

            var isFinished = newCells.All(cell => cell.Type != CellType.Box);
            return new Game(newCells.ToArray(), game.MonitorKeyboard, game.MonitorMouseClicks, new Size(game.Width, game.Height), game.Id, isFinished, game.Score);
        }
    }
    
    
}