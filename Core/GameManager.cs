using System;
using game.Core;
using game.Commands;
using game.Data;
using game.Interface;
using game.Services;
using game.Models;
using System.Linq;

namespace game.Core
{
    class GameManager
    {
        private IGameService _gameService;

        public GameManager(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void PlayTicTacToeGame(BaseAccount currentPlayer, BaseAccount opponent)
        {
            if (currentPlayer == null || opponent == null)
            {
                Console.WriteLine("No players found. Please log in to play.");
                return;
            }

            var game = new TicTacToeGame();

            Random random = new Random();
            bool currentPlayerIsX = random.Next(2) == 0; 
            string currentPlayerMarker = currentPlayerIsX ? "X" : "O";
            string opponentMarker = currentPlayerIsX ? "O" : "X";

            Console.WriteLine($"Player {currentPlayer.UserName} will play as {currentPlayerMarker}.");
            Console.WriteLine($"Player {opponent.UserName} will play as {opponentMarker}.");
            Console.WriteLine("Press Enter to start the game...");
            Console.ReadLine();

            bool gameOver = false;
            int row, col;
            string result = "";

            while (!gameOver)
            {
                Console.Clear();
                game.DisplayBoard();

                if ((game.GetCurrentPlayer() == 'X' && currentPlayerIsX) || (game.GetCurrentPlayer() == 'O' && !currentPlayerIsX))
                {
                    Console.WriteLine($"Player {currentPlayer.UserName}, it's your turn! ({game.GetCurrentPlayer()})");
                    Console.Write("Enter the row (1-3): ");
                    if (!int.TryParse(Console.ReadLine(), out row) || row < 1 || row > 3)
                    {
                        Console.WriteLine("Invalid row. Please try again.");
                        continue;
                    }
                    Console.Write("Enter the column (1-3): ");
                    if (!int.TryParse(Console.ReadLine(), out col) || col < 1 || col > 3)
                    {
                        Console.WriteLine("Invalid column. Please try again.");
                        continue;
                    }

                    if (!game.MakeMove(row - 1, col - 1))
                    {
                        Console.WriteLine("Invalid move, try again.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"Player {opponent.UserName} ({game.GetCurrentPlayer()}) is making a move...");
                    do
                    {
                        row = random.Next(0, 3);
                        col = random.Next(0, 3);
                    } while (!game.MakeMove(row, col));
                }

                if (game.CheckWin())
                {
                    Console.Clear();
                    game.DisplayBoard();

                    BaseAccount winner = (game.GetCurrentPlayer() == 'X') ? opponent : currentPlayer;
                    BaseAccount loser = (winner == currentPlayer) ? currentPlayer : opponent;

                    if (winner == currentPlayer)
                    {
                        currentPlayer.WinGame(game, opponent.UserName);
                        opponent.LoseGame(game, currentPlayer.UserName);
                        result = "Win";
                    }
                    else
                    {
                        currentPlayer.LoseGame(game, opponent.UserName);
                        opponent.WinGame(game, currentPlayer.UserName);
                        result = "Lose";
                    }

                    Console.WriteLine($"Player {winner.UserName} ({game.GetCurrentPlayer()}) wins!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    gameOver = true;
                }
                else if (game.CheckDraw())
                {
                    Console.Clear();
                    game.DisplayBoard();
                    result = "Draw";
                    currentPlayer.DrawGame(game, opponent.UserName);
                    opponent.DrawGame(game, currentPlayer.UserName);
                    Console.WriteLine("It's a draw!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    gameOver = true;
                }
            }

            _gameService.RecordGame(new Game(currentPlayer.UserName, opponent.UserName, result, game.CalculateRating(), currentPlayer.CurrentRating, game.GetType().Name));
        }
    }
}