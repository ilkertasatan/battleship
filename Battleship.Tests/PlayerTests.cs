using System.Collections.Generic;
using System.Linq;
using Battleship.Application;
using Battleship.Application.Games;
using Battleship.Application.Players;
using Battleship.Application.Ships;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class PlayerTests
    {
        private IPlayer _sut;
        
        [Fact]
        public void Should_Return_Hit_Result_When_A_Ship_Is_Hit()
        {
            var expectedGame = GivenGame();
            var expectedGrid = expectedGame.Player.GameBoard.Grids.First(g => g.IsShipPlacedOn);
            _sut = expectedGame.Player;

            var actualResult = _sut.FireShot(expectedGrid.Coordinate);

            actualResult.Should().BeOfType<ShotResult>().Which.Should().Be(ShotResult.Hit);
        }
        
        [Fact]
        public void Should_Return_Miss_Result_When_Ship_Is_Missed()
        {
            var expectedGame = GivenGame();
            var expectedGrid = expectedGame.Player.GameBoard.Grids.First(g => !g.IsShipPlacedOn);
            _sut = expectedGame.Player;

            var actualResult = _sut.FireShot(expectedGrid.Coordinate);

            actualResult.Should().BeOfType<ShotResult>().Which.Should().Be(ShotResult.Miss);
        }
        
        [Fact]
        public void Should_Return_Sink_Result_When_A_Ship_Is_Sunk()
        {
            var expectedGame = GivenGame();
            var expectedShip = new BattleShip
            {
                Hits = 4
            };
            expectedGame.Player.GameBoard.Ships = new List<IShip>
            {
                expectedShip
            };
            expectedGame.Player.GameBoard.Grids = new List<IGrid>
            {
                new Grid(1, 1)
                {
                    GridType = GridType.Battleship,
                    ShipId = expectedShip.ShipId
                }
            };
            _sut = expectedGame.Player;

            var actualResult = _sut.FireShot(new Coordinate(1, 1));

            actualResult.Should().BeOfType<ShotResult>().Which.Should().Be(ShotResult.Sink);
        }

        private static Game GivenGame()
        {
            var game = new Game(new Player("player"));
            game.Start();

            return game;
        }
    }
}