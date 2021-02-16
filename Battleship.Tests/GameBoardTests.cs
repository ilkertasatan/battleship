using Battleship.Application.Games;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class GameBoardTests
    {
        [Fact]
        public void Should_Create_New_Board_Given_Row_And_Column()
        {
            const int expectedRow = 10;
            const int expectedColumn = 10;
            var sut = new GameBoard(expectedRow, expectedColumn);

            sut.Row.Should().Be(expectedRow);
            sut.Column.Should().Be(expectedColumn);
        }
    }
}