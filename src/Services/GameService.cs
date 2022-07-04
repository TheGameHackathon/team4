using System;
using System.Drawing;
using thegame.Models.Entities;

namespace thegame.Services
{
    public class GameService : IGameService
    {
        public Game MakeMove(Game game, UserInput userInput)
        {
            var currentPos = game.Player;
            var nextPos = userInput.Move switch
            {
                Move.Up => currentPos + new Position(0, -1),
                Move.Down => currentPos + new Position(0, 1),
                Move.Left => currentPos + new Position(-1, 0),
                Move.Right => currentPos + new Position(1, 0),
                _ => throw new ArgumentOutOfRangeException()
            };

            game.Player = nextPos;
            return game;
        }
    }
}