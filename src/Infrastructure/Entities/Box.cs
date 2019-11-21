using thegame.Models;

namespace thegame.Infrastructure.Entities
{
    public class Box : CellDto
    {
        public Box(string id, Vec pos, string type, string content, int zIndex) : base(id, pos, type, content, zIndex)
        {
        }
    }
}