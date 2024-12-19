using System;
using System.Collections.Generic;
using game.Models;

namespace game.UI
{
    static class StatsUI
    {
        public static void DisplayStats(BaseAccount account)
        {
            Console.WriteLine();
            Console.WriteLine($"Player: {account.UserName}, Current Rating: {account.CurrentRating}, Games Played: {account.GamesCount}");

            if (account.GamesCount > 0)
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine("Index | Opponent     | Result | Rating | Current | GameId | Game Type");
                Console.WriteLine("---------------------------------------------------------------------");

                var gameHistory = account.GetGameHistory();
                int index = 1;

                foreach (var game in gameHistory)
                {
                    Console.WriteLine($"{index,-5} | {game.OpponentName,-12} | {game.Result,-6} | {game.Rating,-6} | {game.CurrentRating, -7} | {game.GameId, -6} | {game.GameType}");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("No games played yet.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
