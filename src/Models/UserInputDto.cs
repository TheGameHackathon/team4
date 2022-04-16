namespace thegame.Models
{
    public class UserInputDto
    {
        public UserInputDto(int keyPressed)
        {
            KeyPressed = keyPressed;
        }

        public int KeyPressed { get; set; }
    }
}