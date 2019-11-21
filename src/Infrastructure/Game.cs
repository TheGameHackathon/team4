using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Parsing.ExpressionVisitors.MemberBindings;
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

        public Game() => level = Level.First();
        // public Game() => level = LevelParser.ParseFromFile("LEVELS.txt"); //TestData.FirstLevel();

        public bool CheckPosition(string type, Vec position)
        {
            foreach (var cell in level.Map)
            {
                if (cell.Type == type && cell.Pos.X == position.X && cell.Pos.Y == position.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void MovePlayer(Direction direction)
        {
            var playerPos = level.GetPlayerPosition();

            var validMove = CheckValidMove(playerPos, direction);
            
            if (!validMove)
            {
                return;
            }

            var newPosPlayer = GetNextPosition(playerPos, direction);
             
            if (CheckPosition("box", newPosPlayer) || CheckPosition("boxOnTarget", newPosPlayer))
            {
                if (!CheckValidMove(newPosPlayer, direction))
                {
                    return;
                }

                var newPosOfBox = GetNextPosition(newPosPlayer, direction);
                Move(newPosPlayer, newPosOfBox);
                
            }
            Move(playerPos, newPosPlayer);
        }

        public bool CheckValidMove(Vec vector, Direction direction)
        {
            if (direction == Direction.Up)
            {
                vector.Y -= 1;
                return vector.Y >= 0 && !CheckPosition("wall", vector);
            }
            else if (direction == Direction.Left)
            {
                vector.X -= 1;
                return (vector.X - 1) >= 0 && !CheckPosition("wall", vector);
            }
            else if (direction == Direction.Right)
            {
                vector.X += 1;
                return (vector.X + 1) < level.Width && !CheckPosition("wall", vector);
            }
            else if (direction == Direction.Down)
            {
                vector.Y += 1;
                return (vector.Y + 1) < level.Height && !CheckPosition("wall", vector);
            }
            else
            {
                return false;
            }
        }

        public Vec GetNextPosition(Vec pastVec, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    pastVec.Y -= 1;
                    break;
                case Direction.Left:
                    pastVec.X -= 1;
                    break;
                case Direction.Right:
                    pastVec.X += 1;
                    break;
                case Direction.Down:
                    pastVec.Y += 1;
                    break;
            }
            Vec vec = new Vec(pastVec.X, pastVec.Y);
            return vec;
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

        public Game FromRequest() => throw new NotImplementedException();

        public ObjectResult ToResponse() =>
            new ObjectResult(
                new GameDto(level.Map, true, true, level.Width, level.Height, Id, false, score)
            );
    }
}