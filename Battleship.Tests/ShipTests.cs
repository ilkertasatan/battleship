using Battleship.Application.Ships;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class ShipTests
    {
        [Fact]
        public void Should_Create_BattleShip()
        {
            var sut = new BattleShip();

            sut.Size.Should().Be(ShipSize.BattleShip);
            sut.ShipId.Should().NotBeEmpty();
        }

        [Fact]
        public void Should_Create_Destroyer()
        {
            var sut = new Destroyer();

            sut.Size.Should().Be(ShipSize.Destroyer);
            sut.ShipId.Should().NotBeEmpty();
        }
    }
}