namespace TicTacToe;
public class UI
{
    public void RenderBoard(IBoard board)
    {
        for (var i = 0; i < 9; i++)
        {
            if (i > 2 && i%3 == 0)
            {
                Console.WriteLine("\n---------");
            }
            Console.Write(board.IsEmpty(i) ? '.' : board.Get(i));
            if (i % 3 < 2)
                Console.Write(" | ");
        }
    }
    
}