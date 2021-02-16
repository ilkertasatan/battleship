using System;
using System.Linq;
using Battleship.Application.Extensions;
using Battleship.Application.Games;

namespace Battleship.Application.Players
{
    public class Player : IPlayer
    {
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
            GameBoard = new GameBoard(
                BoardSize.Row,
                BoardSize.Column);
        }

        public string Name { get; }
        public IGameBoard GameBoard { get; set; }

        public ShotResult FireShot(Coordinate coordinate)
        {
            var grid = GameBoard.Grids.First(g => g.Coordinate.Row == coordinate.Row &&
                                                  g.Coordinate.Column == coordinate.Column);

            if (!grid.IsShipPlacedOn)
            {
                grid.GridType = GridType.Miss;
                return ShotResult.Miss;
            }

            var ship = GameBoard.Ships.First(s => s.ShipId == grid.ShipId);

            ship.IncreaseHit();
            grid.GridType = GridType.Hit;

            return ship.IsSunk() ? ShotResult.Sink : ShotResult.Hit;
        }
    }
}