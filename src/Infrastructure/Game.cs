using System;
using Microsoft.AspNetCore.Mvc;
using thegame.Infrastructure.Common;
using thegame.Models;

namespace thegame.Infrastructure
{
    public class Game
    {
        Level level;

        public Game() => level = Level.FromSource(new []{ "www", "wpw", "www"});

        public void MovePlayer(Direction direction) => throw new NotImplementedException();

        public Game FromRequest() => throw new NotImplementedException();

        public ObjectResult ToResponse() =>
            new ObjectResult(
                new GameDto(level.Map, true, false, level.Width, level.Height, new Guid(), false, 0)
            );
    }
}