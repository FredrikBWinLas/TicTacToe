namespace TicTacToe;
public delegate void ClearOutputDelegate();
public delegate void WriteOutputDelegate(string message);

public class UI
{
    public required ClearOutputDelegate ClearOutput { get; set; }
    public required WriteOutputDelegate WriteOutput { get; set; }

    public void Print(string message) => WriteOutput(message);

    public void RenderHeader()
    {
        Print(" TTTTT  III  CCC   TTTTT   A   CCC   TTTTT  OOO  EEEEE\n");
        Print("   T     I   C       T    A A  C       T   O   O E    \n");
        Print("   T     I   C       T   AAAAA C       T   O   O EEEE \n");
        Print("   T     I   C       T   A   A C       T   O   O E    \n");
        Print("   T    III  CCC     T   A   A  CCC    T    OOO  EEEEE\n\n\n");
    }
    public void RenderBoard(IBoard board)
    {
        var boardItems = new char[9];
        for (var i = 0; i < 9; i++)
        {
            boardItems[i] = board.IsEmpty(i) ? ' ' : board.Get(i);
        }
        RenderHorizontalRow();
        RenderVerticalRow();
        RenderVerticalRow(boardItems[0], boardItems[1], boardItems[2]);
        RenderVerticalRow();
        RenderHorizontalRow();
        RenderVerticalRow();
        RenderVerticalRow(boardItems[3], boardItems[4], boardItems[5]);
        RenderVerticalRow();
        RenderHorizontalRow();
        RenderVerticalRow();
        RenderVerticalRow(boardItems[6], boardItems[7], boardItems[8]);
        RenderVerticalRow();
        RenderHorizontalRow();
    }

    private void RenderHorizontalRow()
    {
        Print(GetBoardPadding() + "+-----+-----+-----+\n");
    }

    private void RenderVerticalRow(char cell1 = ' ', char cell2 = ' ', char cell3 = ' ')
    {
        Print(GetBoardPadding() + $"|  {cell1}  |  {cell2}  |  {cell3}  |\n");
    }

    private string GetBoardPadding() => new(' ', 18);
}