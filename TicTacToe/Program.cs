using TicTacToe;

var game = new Game();
var ui = new UI() { WriteOutput = Console.Write, ClearOutput = Console.Clear };

var botPlayer = new BotPlayer();
var consolePlayer = new ConsolePlayer() { ReadInput = Console.ReadLine };
var improvedBotPlayer = new ImprovedBotPlayer();

new ConsoleGame(game, ui, botPlayer, improvedBotPlayer);