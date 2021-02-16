using System;

namespace Battleship.Application.Ships
{
    public class Destroyer : IShip
    {
        public Destroyer()
        {
            ShipId = Guid.NewGuid().ToString();
            Size = ShipSize.Destroyer;
        }

        public string ShipId { get; }
        public int Size { get; }
        public int Hits { get; set; }
    }
}