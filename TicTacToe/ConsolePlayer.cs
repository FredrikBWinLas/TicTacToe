namespace TicTacToe;
public delegate string? ReadInputDelegate();

public class ConsolePlayer : IPlayer
{
    public required ReadInputDelegate ReadInput { get; set; }
    public bool IsBot => false;

    public string Name { get; set; } = "ConsolePlayer";

    public int GetNextMove(IBoard board)
    {
        return KeyInputToIndex(ReadInput());
    }
    private int KeyInputToIndex(string? inputString)
    {
        if (inputString == null)
            return -1;

        int.TryParse(inputString, out var input);

        return input switch
        {
            7 => 0,
            8 => 1,
            9 => 2,
            4 => 3,
            5 => 4,
            6 => 5,
            1 => 6,
            2 => 7,
            3 => 8,
            _ => -1
        };
    }
}
