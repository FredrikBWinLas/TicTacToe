
namespace TicTacToe;
public class Board : IBoard
{
    private readonly char[] _boardData = new char[9];

    public void Init() => Array.Fill(_boardData, ' ');
    public char Get(int index) => _boardData[index];
    public void Set(int index, char player)
    {
        if (player != 'X' && player != 'O' && player != ' ')
            throw new ArgumentException("Wrong character type. Valid characters are 'X' or 'O'.");

        _boardData[index] = player;
    }

    public override string ToString() => new string(_boardData);

    public bool IsEmpty(int index) => Get(index) == ' ';
}
