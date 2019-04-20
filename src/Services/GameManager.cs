using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thegame.Models;

namespace thegame.Services
{
    public class GameManager
    {
        private Dictionary<Guid, FloodFillGame> games = new Dictionary<Guid, FloodFillGame>();

        public Guid AddGame(int level)
        {
            var key = Guid.NewGuid();
            games.Add(key, new FloodFillGame(GameService.GetCells(level), true,true, 5 * level, 3 * level, key,false,0));
            return key;
        }

        public FloodFillGame GetGameById(Guid id) => games.ContainsKey(id) ? games[id] : null;

        public FloodFillGame[] GetAllGames() => games.Values.ToArray();

        public FloodFillGame[] GetAllFinishedGames() => games.Values.Where(g=>g.IsFinished==true).ToArray();
    }
}
