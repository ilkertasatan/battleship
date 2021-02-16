using System;

namespace Battleship.Application.Ships
{
    public class BattleShip : IShip
    {
        public BattleShip()
        {
            ShipId = Guid.NewGuid().ToString();
            Size = ShipSize.BattleShip;
        }

        public string ShipId { get; }
        public int Size { get; }
        public int Hits { get; set; }
    }
}