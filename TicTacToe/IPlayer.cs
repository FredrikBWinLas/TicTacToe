namespace TicTacToe;

public interface IPlayer
{
    bool IsBot { get; }
    string Name { get; set; }
    int GetNextMove(IBoard board);
}