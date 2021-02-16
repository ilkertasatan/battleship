using System.Collections.Generic;
using Battleship.Application.Ships;

namespace Battleship.Application.Games
{
    public class GameBoard : IGameBoard
    {
        public GameBoard(int row, int column)
        {
            Row = row;
            Column = column;
            Grids = Grid.NewGrid(row, column);
            Ships = new List<IShip>
            {
                new BattleShip(),
                new Destroyer(),
                new Destroyer()
            };
        }

        public int Row { get; }
        public int Column { get; }
        public IList<IGrid> Grids { get; set; }
        public IList<IShip> Ships { get; set; }
    }
}