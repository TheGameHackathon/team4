using thegame.Models;

namespace thegame.Services.Abstractions
{
    public interface IMoveService
    {
        GameDto GetMove(UserInputForMovesPost userInput);
    }
}