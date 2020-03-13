using thegame.Models;

namespace thegame.Services.Abstractions
{
    public interface IGameService
    {
        GameDto CreateNewGame();
    }
}