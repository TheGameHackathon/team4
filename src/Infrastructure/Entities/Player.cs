using thegame.Models;

namespace thegame.Infrastructure.Entities
{
    public class Player : CellDto
    {
        public Player(Vec pos) : base("player", pos, "", "", 1)
        {
        }
    }
}