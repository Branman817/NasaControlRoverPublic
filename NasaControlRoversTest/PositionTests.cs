using NasaControlRovers.Models;
using Xunit;

namespace NasaControlRoversTest
{
    public class PositionTests
    {
        [Fact]
        public void Position_UpdatePosition_Should_UpdateCooridnates()
        {
            var testPosition = new Position(2, 2, "N");

            testPosition.UpdatePosition('L');
            Assert.Equal("2 2 W", testPosition.CurrentPosition());

            testPosition.UpdatePosition('R');
            testPosition.UpdatePosition('R');
            testPosition.UpdatePosition('M');
            Assert.Equal("3 2 E", testPosition.CurrentPosition());

            testPosition.UpdatePosition('R');
            testPosition.UpdatePosition('M');
            Assert.Equal("3 1 S", testPosition.CurrentPosition());
        }

        [Fact]
        public void Position_UpdatePosition_Should_Throw_Exception_ForInvalidInstruction()
        {
            try
            {
                var testPosition = new Position(2, 2, "N");
                testPosition.UpdatePosition('E');
            }
            catch (Exception ex)
            {
                Assert.Equal("Invalid input was entered", ex.Message);
            }
        }
    }
}
