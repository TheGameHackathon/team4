using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame.Services
{
    public class GameManager
    {

        private Dictionary<Guid, FloodFillGame> games =new Dictionary<Guid, FloodFillGame>();

        public Guid AddGame( int level)
        {
            var key = Guid.NewGuid();
            games.Add(key, new  FloodFillGame(TestData.GetCells(level), false,true, 5 * level, 3 * level, key,false,0));
            return key;
        }


        public FloodFillGame GetGameById(Guid id)
        {
            if (games.ContainsKey(id))
            {
                return games[id];
            }
            return null;
        }

    }
}
