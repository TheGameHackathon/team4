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
        private int currentScore = 0;
        private int fails = 0;

        public Game()
        {
            var rand = new Random();
            var tileIdsCount = new int[16];

            tiles = Enumerable.Range(1, 16).Concat(Enumerable.Range(1, 16)).OrderBy(a => Guid.NewGuid()).ToArray();
        }

        public int[] GameState => tiles.ToArray(); 

        public GameState RevertTile(int tileIndex)
        {
            if (state[tileIndex] > 0)
            {
                throw new InvalidOperationException();
            }
            
            if (currentReverted < 0)
            {
                state[tileIndex] = tiles[tileIndex]; 
                currentReverted = tileIndex;
                return new GameState{Fails = fails,Score = currentScore,State = state};
            }

            state[tileIndex] = tiles[tileIndex];
            
            var tmpState = state.ToArray();
            if (tiles[currentReverted] != tiles[tileIndex])
            {
                state[tileIndex] = state[currentReverted] = 0;
                currentReverted = -1;
                currentScore -= 10;
                fails++;
            }
            else
                currentScore += 100;
            return new GameState{Fails = fails,Score = currentScore,State = tmpState};
        }
    }
}