using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Infrastructure.Common;
using thegame.Models;
using thegame.Services;

namespace thegame.Infrastructure
{
    public class Game
    {
        public readonly Guid Id = Guid.NewGuid();
        Level level;
        int score = 0;

        public Game(Vec vector) => level = TestData.FirstLevel(vector);

        public bool CheckPosition(string type, Vec position)
        {
            foreach (var cell in level.Map)
            {
                if (cell.Type == type && cell.Pos.Equals(position))
                {
                    return true;
                }
            }

            return false;
        }

        public void MovePlayer(Direction direction) => throw new NotImplementedException();

        public void MovePlayer(Vec newPosition)
        {
            level.Map.First(c => c.Type == "player").Pos = newPosition;
        }

        public Game FromRequest() => throw new NotImplementedException();

        public ObjectResult ToResponse() =>
            new ObjectResult(
                new GameDto(level.Map, true, true, level.Width, level.Height, new Guid(), false, 0)
            );
    }
}