using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Infrastructure.Common;
using thegame.Models;

namespace thegame.Infrastructure
{
    public class Game
    {
        public readonly Guid Id = Guid.NewGuid();
        Level level;
        bool isFinished = false;
        int score = 0;

        public Game() => level = Level.First();

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

        public void MovePlayer(Direction direction)
        {
            isFinished = false;
            var playerPos = level.GetPlayerPosition();

            var validMove = CheckValidMove(playerPos, direction);

            if (!validMove)
            {
                return;
            }

            var newPosPlayer = playerPos.GetNextPosition(direction);

            if (CheckPosition("box", newPosPlayer) || CheckPosition("boxOnTarget", newPosPlayer))
            {
                if (!CheckValidMove(newPosPlayer, direction))
                {
                    return;
                }

                var newPosOfBox = newPosPlayer.GetNextPosition(direction);
                Move(newPosPlayer, newPosOfBox);
            }

            Move(playerPos, newPosPlayer);
        }

        public bool CheckValidMove(Vec vector, Direction direction)
        {
            Vec vec = new Vec(vector.X, vector.Y);
            if (direction == Direction.Up)
            {
                vec.Y -= 1;
                return vec.Y >= 0 && !CheckPosition("wall", vec);
            }
            else if (direction == Direction.Left)
            {
                vec.X -= 1;
                return (vec.X - 1) >= 0 && !CheckPosition("wall", vec);
            }
            else if (direction == Direction.Right)
            {
                vec.X += 1;
                return (vec.X + 1) < level.Width && !CheckPosition("wall", vec);
            }
            else if (direction == Direction.Down)
            {
                vec.Y += 1;
                return (vec.Y + 1) < level.Height && !CheckPosition("wall", vec);
            }
            else
            {
                return false;
            }
        }

        public void Move(Vec pastVec, Vec newVec)
        {
            foreach (var cell in level.Map)
            {
                if (cell.Pos.Equals(pastVec))
                {
                    cell.Pos = newVec;
                }
            }
        }

        public void MovePlayer(Vec newPosition)
        {
            level.Map.First(c => c.Type == "player").Pos = newPosition;
        }

        public void CheckForLevelIsFinished()
        {
            if (level.IsFinished())
            {
                isFinished = true;
                
                var nextLevel = level.Next();
                if (nextLevel != null) level = nextLevel;
            }
        }

        public ObjectResult ToResponse() =>
            new ObjectResult(
                new GameDto(level.Map, true, false, level.Width, level.Height, Id, isFinished, score)
            );
    }
}