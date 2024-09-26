using TicTacToe;

var game = new Game();
game.NewGame();

var ui = new UI();

var player1 = new ConsolePlayer() { Name = "Player 1" };
var player2 = new ConsolePlayer() { Name = "Player 2" };
IPlayer currentPlayer = player1;

while (!game.IsBoardFull())
{
    Move();
    RenderGame();
    if (game.HasAnyPlayerWon())
    {
        Console.WriteLine($"Player {currentPlayer.Name} won!");
        break;
    }
    currentPlayer = currentPlayer == player1 ? player2 : player1;
}

void Move()
{
    while (true)
    {
        try
        {
            game.Move(GetMoveIndex());
            return;
        }
        catch
        {
            Console.WriteLine("Bad move, try again!");
        }
    }
}

int GetMoveIndex()
{
    if (currentPlayer.IsBot)
    {
        return player1.GetIndexForMove(game.Board, game.CurrentPlayer);
    }
    Console.Write("Do move:");
    return int.Parse(Console.ReadLine() ?? "-1");
}
void RenderGame()
{
    ui.RenderBoard(game.Board);
}

