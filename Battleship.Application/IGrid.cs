namespace Battleship.Application
{
    public interface IGrid
    {
        string ShipId { get; set; }
        bool IsShipPlacedOn { get; }
        GridType GridType { get; set; }
        Coordinate Coordinate { get; }
    }
}