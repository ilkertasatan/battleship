namespace Battleship.Application
{
    public interface IGame
    {
        IPlayer Player { get; set; }
        bool IsOver { get; }
    }
}