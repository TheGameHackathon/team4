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
                Move.Up => new VectorDto(0, -1),
                Move.Down => new VectorDto(0, 1),
                Move.Left => new VectorDto(-1, 0),
                Move.Right => new VectorDto(1, 0),
                _ => currentPos
            };

            return MoveNext(game, cell, currentPos, nextPos);
        }

        private GameDto MoveNext(GameDto gameDto, CellDto player, VectorDto currentPos, VectorDto nextPos)
        {
            var map = mapRepository.GetMapByGameId(gameDto.Id);
            var next = currentPos + nextPos;
            var nextCell = map.Table[next.X][next.Y];
            if (nextCell is not null)
            {
                var nextType = nextCell.Type;
                if (nextType == "wall")
                    return gameDto;
                var nextNext = next + nextPos;
                if (nextType is "box" or "boxOnTarget")
                {
                    if (map.Table[nextNext.X][nextNext.Y] is not null)
                        return gameDto;
                    var box = map.Table[next.X][next.Y];
                    map.Table[nextNext.X][nextNext.Y] = box;
                    map.Table[next.X][next.Y] = null;
                    box.Pos.X += nextPos.X;
                    box.Pos.Y += nextPos.Y;
                }
            }

            if (IsWin(map))
                gameDto.IsFinished = true;
            gameDto.Score += 1;
            player.Pos = currentPos + nextPos;
            return gameDto;
        }

        public bool IsWin(Map map)
        {
            var targets = map.Targets.Select(target => (target.X, target.Y)).ToHashSet();
            return map.Boxes.All(box => targets.Contains((box.X, box.Y)));
        }
    }
}