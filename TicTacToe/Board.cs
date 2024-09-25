namespace TicTacToe;
public class Board
{
    public string BoardData { get; set; } = "";

    public void Init()
    {
        BoardData = "         ";
    }
}
