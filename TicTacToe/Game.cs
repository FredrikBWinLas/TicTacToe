
using System.Text.RegularExpressions;

namespace TicTacToe;
public class Game
{
    private char _currentPlayer = 'X';
    public IBoard Board { get; }
    public char CurrentPlayer => _currentPlayer;
    public Game()
    {
        Board = new Board();
    }

    public void NewGame()
    {
        _currentPlayer = 'X';
        Board.Init();
    }

    public void Move(int index)
    {
        if (!Board.IsEmpty(index))
            throw new ArgumentException();

        Board.Set(index, CurrentPlayer);
        ChangePlayer();
    }

    public bool IsBoardFull() => Board.ToString().IndexOf(' ') < 0;
    public bool HasAnyPlayerWon()
    {
        return HasPlayerWon('X') || HasPlayerWon('O');
    }
    public bool HasPlayerWon(char p)
    {
        //Rows
        if (Regex.Match(Board.ToString(), $"^{p}{{3}}.{{6}}$").Success) 
            return true;
        if (Regex.Match(Board.ToString(), $"^...{p}{{3}}...$").Success) 
            return true;
        if (Regex.Match(Board.ToString(), $"^.{{6}}{p}{{3}}$").Success) 
            return true;
        //Cols
        if (Regex.Match(Board.ToString(), $"^{p}..{p}..{p}..$").Success)
            return true;
        if (Regex.Match(Board.ToString(), $"^.{p}..{p}..{p}.$").Success)
            return true;
        if (Regex.Match(Board.ToString(), $"^..{p}..{p}..{p}$").Success)
            return true;
        //Diagonals
        if (Regex.Match(Board.ToString(), $"^{p}...{p}...{p}$").Success)
            return true;
        if (Regex.Match(Board.ToString(), $"^..{p}.{p}.{p}..$").Success)
            return true;

        return false;
    }

    private void ChangePlayer() => _currentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
}
