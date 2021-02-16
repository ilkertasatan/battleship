using System;
using System.Linq;

namespace Battleship.Application.Ships
{
    public class RandomShip : IPlaceShip
    {
        public void PlaceShips(IGameBoard board)
        {
            var random = new Random();

            foreach (var ship in board.Ships)
            {
                while (true)
                {
                    var startRow = random.Next(1, board.Row + 1);
                    var startColumn = random.Next(1, board.Column + 1);

                    var endRow = startRow;
                    var endColumn = startColumn;
                    var orientation = NextOrientation();

                    if (orientation == ShipOrientation.Horizontal)
                        endRow = startRow + ship.Size;
                    else
                        endColumn = startColumn + ship.Size;

                    if (endRow > board.Row || endColumn > board.Column)
                        continue;
                    
                    var grids = board.Grids
                        .Where(g => g.Coordinate.Row >= startRow &&
                                    g.Coordinate.Column >= startColumn &&
                                    g.Coordinate.Row <= endRow &&
                                    g.Coordinate.Column <= endColumn)
                        .ToList();

                    if (grids.Any(g => g.IsShipPlacedOn))
                        continue;

                    foreach (var grid in grids)
                    {
                        grid.ShipId = ship.ShipId;
                        grid.GridType = ship switch
                        {
                            Destroyer _ => GridType.Destroyer,
                            BattleShip _ => GridType.Battleship,
                            _ => throw new ArgumentOutOfRangeException()
                        };
                    }
                    
                    break;
                }
            }
        }

        private static ShipOrientation NextOrientation()
        {
            return new Random().Next(0, 2) % 2 == 0 ? 
                ShipOrientation.Horizontal :
                ShipOrientation.Vertical;
        }
    }
}