using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thegame.Models
{
    public class FloodFillGame : GameDto,IFloodFillGame
    {
        public FloodFillGame(CellDto[] cells, bool monitorKeyboard, bool monitorMouseClicks, int width, int height, Guid id, bool isFinished, int score) : base(cells, monitorKeyboard, monitorMouseClicks, width, height, id, isFinished, score)
        {
        }

        public void MakeMove(string color)
        {
            throw new NotImplementedException();
        }
    }
}
