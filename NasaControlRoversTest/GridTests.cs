using NasaControlRovers.Models;
using Xunit;

namespace NasaControlRoversTest
{
    public class GridTests
    {
        [Fact]
        public void Grid_Should_DetermineIf_Position_IsOutOfBounds()
        {
            var testGrid = new Grid(4, 7);
            var testPosition1 = new Position(3, 4, "N");

            var isOutOfBounds = testGrid.isOutOfBounds(testPosition1);
            Assert.False(isOutOfBounds);

            var testPosition2 = new Position(5, 4, "N");
            isOutOfBounds = testGrid.isOutOfBounds(testPosition2);
            Assert.True(isOutOfBounds);
        }
    }
}
