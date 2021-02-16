using Battleship.Application;
using Battleship.Application.Extensions;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class InputExtensionsTests
    {
        [Theory]
        [InlineData("A3", 1, 3)]
        [InlineData("B7", 2, 7)]
        [InlineData("C8", 3, 8)]
        [InlineData("D6", 4, 6)]
        [InlineData("E1", 5, 1)]
        [InlineData("F2", 6, 2)]
        [InlineData("G5", 7, 5)]
        [InlineData("H6", 8, 6)]
        [InlineData("I7", 9, 7)]
        [InlineData("J9", 10, 9)]
        public void Should_Convert_Coordinate_Given_Valid_Input(string expectedInput, int expectedX, int expectedY)
        {
            var expectedResult = new Coordinate(expectedX, expectedY);

            var actualResult = expectedInput.ToCoordinate();

            actualResult.IsValid().Should().BeTrue();
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("invalid-input")]
        [InlineData("N1")]
        [InlineData("Z99")]
        public void Should_Not_Convert_Coordinate_Given_Invalid_Input(string expectedInput)
        {
            var actualResult = expectedInput.ToCoordinate().IsValid();

            actualResult.Should().BeFalse();
        }
    }
}