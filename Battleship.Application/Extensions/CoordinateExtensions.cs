namespace Battleship.Application.Extensions
{
    public static class CoordinateExtensions
    {
        public static bool IsValid(this Coordinate coordinate)
        {
            return coordinate.Row > 0 &&
                   coordinate.Column > 0;
        }
    }
}