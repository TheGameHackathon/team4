using System;

namespace thegame.Models.Dto
{
    public class GameStateDto
    {
        public Guid GameId { get; set; }
        public string UserName { get; set; }
        public FieldStateDto Field { get; set; }
    }
}