using NasaControlRovers.Models;
using Xunit;

namespace NasaControlRoversTest
{
    public class RoverTests
    {
        [Fact]
        public void Rover_CurrentPosition_Should_Return_CorrectOutput_ForValidInput()
        {
            var input = "5 4 S\nMLMMLMRRMMRMMMMM\n0 0 N\nMRMLMRMLMRMLMRMLMRMLMLMRM";
            var inputs = input.Split("\n").ToList();
            var testGrid = new Grid(8, 10);
            var testRover1 = new Rover(testGrid, inputs[0]);
            testRover1.MoveRover(inputs[1]);

            var expectedPosition1 = "2 2 W";
            var currentPosition1 = testRover1.CurrentPosition();
            Assert.Equal(expectedPosition1, currentPosition1);

            var testRover2 = new Rover(testGrid, inputs[2]);
            testRover2.MoveRover(inputs[3]);

            var expectedPosition2 = "4 7 N";
            var currentPosition2 = testRover2.CurrentPosition();
            Assert.Equal(expectedPosition2, currentPosition2);
        }

        [Fact]
        public void Rover_CurrentPosition_Should_Return_InvalidPosition_ForInputError()
        {
            var input = "5 4 O\nMLMMLMRRMMRMMMMM";
            var inputs = input.Split("\n").ToList();
            var testGrid = new Grid(8, 10);
            var testRover1 = new Rover(testGrid, inputs[0]);
            testRover1.MoveRover(inputs[1]);

            var expectedOutput = "Invalid position was given";
            var result = testRover1.CurrentPosition();
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void Rover_CurrentPosition_Should_Return_InvalidInstructions_ForInputError()
        {
            var input = "5 4 S\nMLMMLMRRMMRMMEMM";
            var inputs = input.Split("\n").ToList();
            var testGrid = new Grid(8, 10);
            var testRover1 = new Rover(testGrid, inputs[0]);
            testRover1.MoveRover(inputs[1]);

            var expectedOutput = "invalid instructions were given";
            var result = testRover1.CurrentPosition();
            Assert.Equal(expectedOutput, result);
        }

        [Fact]
        public void Rover_CurrentPosition_Should_SpecifyIf_Rover_WentOutOfBounds()
        {
            var input = "5 4 S\nMLMMLMRRMMRMMMMM\n0 0 N\nMRMLMRMLMRMLMRMLMRMLMLMRM";
            var inputs = input.Split("\n").ToList();
            var testGrid = new Grid(8, 5);
            var testRover1 = new Rover(testGrid, inputs[0]);
            testRover1.MoveRover(inputs[1]);

            var expectedPosition1 = "2 2 W";
            var currentPosition1 = testRover1.CurrentPosition();
            Assert.Equal(expectedPosition1, currentPosition1);

            var testRover2 = new Rover(testGrid, inputs[2]);
            testRover2.MoveRover(inputs[3]);

            var expectedOutput = "before going out of bounds of grid";
            var currentPosition2 = testRover2.CurrentPosition();
            var outOfBounds = currentPosition2.Contains(expectedOutput);
            Assert.True(outOfBounds);
        }
    }
}