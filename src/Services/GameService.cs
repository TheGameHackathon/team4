using System;
using System.Drawing;
using System.Linq;
using thegame.Models.DTO;
using thegame.Models.Entities;

namespace thegame.Services
{
    public class GameService : IGameService
    {
        private readonly MapRepository mapRepository;

        public GameService(MapRepository mapRepository) => this.mapRepository = mapRepository;

        public GameDto MakeMove(GameDto game, UserInput userInput)
        {
            var cell = game.Cells.First(c => c.Type == "player");
            var currentPos = cell.Pos;
            var nextPos = userInput.Move switch
            {
                Move.Up =>  new VectorDto(0, -1),
                Move.Down =>  new VectorDto(0, 1),
                Move.Left => new VectorDto(-1, 0),
                Move.Right =>  new VectorDto(1, 0),
                _ => currentPos
            };

            return MoveNext(game, cell, currentPos, nextPos);
        }

        private GameDto MoveNext(GameDto gameDto, CellDto player, VectorDto currentPos, VectorDto nextPos)
        {
            var map = mapRepository.GetMapByGameId(gameDto.Id);
            var next = currentPos + nextPos;
            if (map.Table[next.X][next.Y] == "wall")
                return gameDto;
            var nextNext = next + nextPos;
            if (map.Table[next.X][next.Y] == "box")
            {
                if (map.Table[nextNext.X][nextNext.Y] == null)
                {

                }
                // return 
            }
            
            var boxesIntersection = map.Boxes.Intersect(map.Targets).ToHashSet();
            foreach (var b in gameDto.Cells)
            {
                if (boxesIntersection.Contains(b.Pos))
                {
                    b.Type = "boxOnTarget";
                    continue;
                }
                b.Type = "box";
            }
            
            player.Pos = currentPos + nextPos;
            return gameDto;
        }
    }
}