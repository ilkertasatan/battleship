using System;

namespace Battleship.Application.Extensions
{
    public static class InputExtensions
    {
        public static Coordinate ToCoordinate(this string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 2)
                return Coordinate.Empty;
            
            var chars = input.ToCharArray();
            var x = chars[0].ToX();
            int.TryParse(chars[1].ToString(), out var y);

            return new Coordinate(x, y);
        }

        private static int ToX(this char c)
        {
            return c switch
            {
                'A' => 1,
                'B' => 2,
                'C' => 3,
                'D' => 4,
                'E' => 5,
                'F' => 6,
                'G' => 7,
                'H' => 8,
                'I' => 9,
                'J' => 10,
                _ => 0
            };
        }
    }
}