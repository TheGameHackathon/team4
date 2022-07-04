namespace thegame.Models.Entities
{
    public enum Move
    {
        Up,
        Down,
        Left,
        Right
    }

    public record UserInput(Move Move);
}