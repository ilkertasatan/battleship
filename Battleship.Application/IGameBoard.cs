using System.Collections.Generic;
using Battleship.Application.Games;

namespace Battleship.Application
{
    public interface IGameBoard
    {
        int Row { get; }
        int Column { get; }
        IList<IGrid> Grids { get; set; }
        IList<IShip> Ships { get; set; }
    }
}