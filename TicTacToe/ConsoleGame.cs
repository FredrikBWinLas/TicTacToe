namespace TicTacToe;
public class ConsoleGame
{
    private readonly Game _game;
    private readonly UI _ui;
    private readonly IPlayer _player1;
    private readonly IPlayer _player2;
    private IPlayer _currentPlayer;

    public ConsoleGame(Game game, UI ui, IPlayer player1, IPlayer player2)
    {
        _game = game;
        _ui = ui;

        _currentPlayer = _player1 = player1;
        _player2 = player2;

        _player1.Name = "X";
        _player2.Name = "O";

        _game.NewGame();

        Render();
        RunGame();
    }

    private void RunGame()
    {
        DoNextMove();
        Render();

        if (_game.HasAnyPlayerWon())
        {
            _ui.Print($"Player {_currentPlayer.Name} won!");
            return;
        }

        if (_game.IsBoardFull())
        {
            _ui.Print("Game Over - It's a Draw!");
            return;
        }

        ChangePlayer();
        RunGame();
    }

    private void DoNextMove()
    {
        try
        {
            if (_currentPlayer.IsBot)
            {
                Thread.Sleep(1000);
            }
            else
            {
                _ui.Print("Do move:");
            }

            _game.Move(_currentPlayer.GetNextMove(_game.Board));
        }
        catch
        {
            _ui.Print("Bad move, try again!\n");
            DoNextMove();
        }
    }

    private void Render()
    {
        _ui.ClearOutput();
        _ui.RenderHeader();
        _ui.RenderBoard(_game.Board);
    }

    private void ChangePlayer() => _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;
}
