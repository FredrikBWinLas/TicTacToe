
using System.Text.RegularExpressions;

namespace TicTacToe;
public class Board : IBoard
{
    private readonly char[] _boardData = new char[9];
    public char[] AllowedCharacters { get; init; } = ['X', 'O', ' '];

    public void Init() => Array.Fill(_boardData, ' ');
    public char Get(int index) => _boardData[index];
    public void Set(int index, char player)
    {
        if (!AllowedCharacters.Contains(player))
            throw new ArgumentException($"Wrong character type. Valid characters are {string.Join(", ", AllowedCharacters)}.");

        _boardData[index] = player;
    }

    public override string ToString() => new string(_boardData);

    public bool IsEmpty(int index) => Get(index) == ' ';
    public bool IsBoardFull() => ToString().IndexOf(' ') < 0;

    public bool HasPlayerWon(char p)
    {
        //Rows
        if (Regex.Match(ToString(), $"^{p}{{3}}.{{6}}$").Success)
            return true;
        if (Regex.Match(ToString(), $"^...{p}{{3}}...$").Success)
            return true;
        if (Regex.Match(ToString(), $"^.{{6}}{p}{{3}}$").Success)
            return true;
        //Cols
        if (Regex.Match(ToString(), $"^{p}..{p}..{p}..$").Success)
            return true;
        if (Regex.Match(ToString(), $"^.{p}..{p}..{p}.$").Success)
            return true;
        if (Regex.Match(ToString(), $"^..{p}..{p}..{p}$").Success)
            return true;
        //Diagonals
        if (Regex.Match(ToString(), $"^{p}...{p}...{p}$").Success)
            return true;
        if (Regex.Match(ToString(), $"^..{p}.{p}.{p}..$").Success)
            return true;

        return false;
    }
}
