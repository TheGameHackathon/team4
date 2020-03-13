using System.Linq;
using thegame.Models;
using thegame.Services.Abstractions;

namespace thegame.Services
{
    public class MoveService : IMoveService
    {
        public GameDto GetMove(UserInputForMovesPost userInput)
        {
            var game = TestData.AGameDto(userInput.ClickedPos ?? new Vec(1, 1));
            if (userInput.ClickedPos != null)
                game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;

            return game;
        }
    }
}