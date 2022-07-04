namespace thegame.Models.Entities
{
    public enum Move
    {
        Up,
        Down,
        Left,
        Right,
        Empty
    }

    public record UserInput(Move Move);
}