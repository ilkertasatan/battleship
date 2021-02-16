using System.Linq;
using Battleship.Application.Extensions;
using Battleship.Application.Ships;

namespace Battleship.Application.Games
{
    public class Game : 
        IGame,
        IStartTheGame
    {
        public Game(IPlayer player)
        {
            Player = player;
        }

        public IPlayer Player { get; set; }
        public bool IsOver
        {
            get
            {
                return Player.GameBoard.Ships.Count(s => s.IsSunk()) >= Player.GameBoard.Ships.Count;
            }
        }

        public void Start()
        {
            new RandomShip().PlaceShips(Player.GameBoard);
        }
    }
}