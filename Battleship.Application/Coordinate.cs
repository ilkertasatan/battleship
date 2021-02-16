namespace Battleship.Application
{
    public class Coordinate
    {
        public static Coordinate Empty = new Coordinate();

        private Coordinate()
        {
        }

        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }
    }
}