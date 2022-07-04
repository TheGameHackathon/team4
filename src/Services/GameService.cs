using System;
using System.Drawing;
using System.Linq;
using thegame.Models.DTO;
using thegame.Models.Entities;

namespace thegame.Services
{
    public class GameService : IGameService
    {
        public GameDto MakeMove(GameDto game, UserInput userInput)
        {
            var cell = game.Cells.First(c => c.Type == "player");
            var currentPos = cell.Pos;
            var nextPos = userInput.Move switch
            {
                Move.Up => currentPos + new VectorDto(0, -1),
                Move.Down => currentPos + new VectorDto(0, 1),
                Move.Left => currentPos + new VectorDto(-1, 0),
                Move.Right => currentPos + new VectorDto(1, 0),
                _ => currentPos
            };

            cell.Pos = nextPos;
            return game;
        }
    }
}