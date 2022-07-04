namespace thegame.Models.Entities
{
    public enum Move
    {
        Up,
        Down,
        Left,
        Right,
        AI,
        Empty
    }

    public record UserInput(Move Move);
}