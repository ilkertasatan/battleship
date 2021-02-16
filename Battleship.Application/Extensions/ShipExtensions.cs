namespace Battleship.Application.Extensions
{
    public static class ShipExtensions
    {
        public static void IncreaseHit(this IShip ship)
        {
            ship.Hits++;
        }

        public static bool IsSunk(this IShip ship)
        {
            return ship.Hits >= ship.Size;
        }
    }
}