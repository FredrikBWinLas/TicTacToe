namespace TicTacToe;

public class ImprovedBotPlayer : BotPlayer
{
    public override int GetNextMove(IBoard board)
    {
        return board.IsEmpty(4) ? 4 : base.GetNextMove(board);
    }
}