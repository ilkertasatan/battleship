using System;
using Battleship.Application;
using Battleship.Application.Extensions;
using Battleship.Application.Games;
using Battleship.Application.Players;

namespace Battleship
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Welcome();
            PromptPlayerName();

            var playerName = Console.ReadLine();

            var game = new Game(new Player(playerName));
            game.Start();

            while (!game.IsOver)
            {
                PromptAgain:
                PromptCoordinate();

                var input = Console.ReadLine();
                var coordinate = input.ToCoordinate();

                if (!coordinate.IsValid())
                {
                    DisplayValidCoordinateMessage();
                    goto PromptAgain;
                }

                var shotResult = game.Player.FireShot(coordinate);
                switch (shotResult)
                {
                    case ShotResult.Hit:
                        DisplayHitMessage();
                        break;
                    case ShotResult.Sink:
                        DisplaySinkMessage();
                        break;
                    case ShotResult.Miss:
                        DisplayMissMessage();
                        break;
                }

                if (!game.IsOver) continue;

                DisplayGameOverMessage();
                break;
            }

            Console.ReadLine();
        }
        
        #region Messages
        
        private static void DisplayGameOverMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("All ships have been sunk. Game is over.");
        }
        
        private static void DisplayHitMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("A ship has been hit.");
        }
        
        private static void DisplaySinkMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Congratulations! A ship has been sunk.");
        }
        
        private static void DisplayMissMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Missed! Try again.");
        }

        private static void DisplayValidCoordinateMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid coordinate.");
        }
        
        private static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("======================================================");
            Console.WriteLine("=========== BattleShip Game For Single Player ========");
            Console.WriteLine("======================================================");
        }

        private static void PromptPlayerName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter your name:");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PromptCoordinate()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the coordinate between A1 and J10");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        #endregion
    }
}