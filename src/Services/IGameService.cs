using thegame.Models.Entities;

namespace thegame.Services
{
    public interface IGameService
    {
        Game MakeMove(Game game, UserInput userInput);
    }
}
