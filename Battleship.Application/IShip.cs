namespace Battleship.Application
{
    public interface IShip
    {
        public string ShipId { get; }
        int Size { get; }
        int Hits { get; set; }
    }
}