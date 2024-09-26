namespace TicTacToe;

public class BotPlayer : IPlayer
{
    public bool IsBot => true;
    public string Name { get; set; }


    public int GetIndexForMove(IBoard board, char playerSymbol)
    {
        throw new NotImplementedException();
    }
}
