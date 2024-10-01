namespace TicTacToe;

public class BotPlayer : IPlayer
{
    public bool IsBot => true;
    public string Name { get; set; } = "BotPlayer";
    private readonly Random _rnd = new();

    public virtual int GetNextMove(IBoard board)
    {
        if (board.IsBoardFull())
            return -1;

        while (true)
        {
            var index = _rnd.Next(0, 9);
            if (board.IsEmpty(index))
                return index;
        }
    }
}