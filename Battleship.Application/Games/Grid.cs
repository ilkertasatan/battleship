using System.Collections.Generic;

namespace Battleship.Application.Games
{
    public class Grid : IGrid
    {
        public Grid(int row, int column)
        {
            Coordinate = new Coordinate(row, column);
            GridType = GridType.Empty;
        }

        public string ShipId { get; set; }
        public GridType GridType { get; set; }
        public Coordinate Coordinate { get; }
        public bool IsShipPlacedOn => !string.IsNullOrEmpty(ShipId);
        
        public static IList<IGrid> NewGrid(int row, int column)
        {
            var grids = new List<IGrid>();
            for (var x = 1; x <= row; x++)
            {
                for (var y = 1; y <= column; y++)
                {
                    grids.Add(new Grid(x, y));
                }
            }

            return grids;
        }
    }
}