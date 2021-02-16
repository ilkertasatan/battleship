namespace Battleship.Application
{
    public interface IPlayer : IFireShot
    {
        string Name { get; }
        IGameBoard GameBoard { get; set;}
    }
}