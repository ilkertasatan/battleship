namespace Battleship.Application
{
    public interface IFireShot
    {
        ShotResult FireShot(Coordinate coordinate);
    }
}