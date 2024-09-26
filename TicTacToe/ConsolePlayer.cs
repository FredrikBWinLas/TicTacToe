namespace TicTacToe;
public class ConsolePlayer : IPlayer
{
    public bool IsBot => false;

    public string Name { get; set; }

    public int GetIndexForMove(IBoard board, char playerSymbol)
    {
        return 0;
    }
}
