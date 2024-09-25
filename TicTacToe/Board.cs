
namespace TicTacToe;
public class Board
{
    public string BoardData { get; set; } = "";

    public void Init()
    {
        BoardData = new string(' ', 9);
    }
    public char Get(int index)
    {
        return BoardData[index];
    }
    public void Set(int index, char player)
    {
        if (player != 'X' && player != 'O')
            throw new ArgumentException("Wrong character type. Valid characters are 'X' or 'O'.");

        var boardArray = BoardData.ToCharArray();
        boardArray[index] = player;
        BoardData = new string(boardArray);
    }
}
