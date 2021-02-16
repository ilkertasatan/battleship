using Battleship.Application.Games;
using Battleship.Application.Players;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class GameTests
    {
        [Fact]
        public void Should_Start_New_Game()
        {
            var sut = new Game(new Player("player"));

            sut.Start();

            sut.Player.GameBoard.Should().NotBeNull();
            sut.Player.GameBoard.Ships
                .Should()
                .HaveCountGreaterThan(0);
            sut.Player.GameBoard.Grids
                .Should()
                .NotBeEmpty()
                .And
                .HaveCount(sut.Player.GameBoard.Row * sut.Player.GameBoard.Column);
        }
    }
}