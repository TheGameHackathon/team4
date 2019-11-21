using System;
using System.Linq;
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

        public Game() => level = TestData.FirstLevel();//LevelParser.ParseFromFile("LEVELS.txt"); //

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

                if(CheckPosition("box", newPosOfBox) || CheckPosition("boxOnTarget", newPosOfBox))
                {
                    return;
                }

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
            var currentCell = level.GetCell(pastVec);
            var futureCell = level.GetCell(newVec);
            if (futureCell != null && futureCell.Type == "target" && currentCell.Type == "box")
            {
                currentCell.Type = "boxOnTarget";
            }
            else if (currentCell.Type == "boxOnTarget")
            {
                currentCell.Type = "box";
            }
            currentCell.Pos = newVec;
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