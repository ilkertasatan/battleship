using Battleship.Application.Extensions;
using Battleship.Application.Ships;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class ShipExtensionsTests
    {
        [Fact]
        public void Should_Increase_Hits()
        {
            const int expectedResult = 3;
            var sut = new BattleShip
            {
                Hits = expectedResult
            };
            
            sut.IncreaseHit();
            var actualResult = sut.Hits;

            sut.IsSunk().Should().BeFalse();
            actualResult.Should().Be(expectedResult + 1);
        }
        
        [Fact]
        public void Should_Sink()
        {
            var sut = new BattleShip
            {
                Hits = ShipSize.BattleShip
            };

            var actualResult = sut.IsSunk();

            actualResult.Should().BeTrue();
        }
    }
}