namespace TicTacToe;
public class Game
{
    public IBoard Board { get; init; } = new Board() { AllowedCharacters = ['X', 'O'] };
    public char CurrentPlayer { get; private set; } = 'X';
    public bool IsBoardFull() => Board.IsBoardFull();

    public void NewGame()
    {
        CurrentPlayer = 'X';
        Board.Init();
    }

    public void Move(int index)
    {
        if (!Board.IsEmpty(index))
            throw new ArgumentException();

        Board.Set(index, CurrentPlayer);
        ChangePlayer();
    }

    public bool HasAnyPlayerWon() => Board.HasPlayerWon('X') || Board.HasPlayerWon('O');

    private void ChangePlayer() => CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
}
