using System;
using System.Linq;

namespace thegame.Model
{
    public class Game
    {
        //TODO make deepcopy
        public Guid Id { get; set; }
        private int[] tiles;
        private int[] state = new int[32];
        private int currentReverted=-1;

        public Game()
        {
            var rand = new Random();
            var tileIdsCount = new int[16];

            tiles = Enumerable.Range(1, 16).Concat(Enumerable.Range(1, 16)).OrderBy(a => Guid.NewGuid()).ToArray();
        }

        public int[] GameState => tiles.ToArray(); 

        public int[] RevertTile(int tileIndex)
        {
            if (state[tileIndex] > 0)
            {
                throw new InvalidOperationException();
            }
            
            if (currentReverted < 0)
            {
                state[tileIndex] = tiles[tileIndex]; 
                currentReverted = tileIndex;
                return state;
            }

            state[tileIndex] = tiles[tileIndex];
            var tmpState = state.ToArray();
            if (tiles[currentReverted] != tiles[tileIndex])
            {
                state[tileIndex] = state[currentReverted] = 0;
                currentReverted = -1;
            }
            return tmpState;
        }
    }
}