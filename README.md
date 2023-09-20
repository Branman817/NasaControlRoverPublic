Coding Test, Problem 1

NasaControlRovers
Brandon Dozier

The NasaControlRovers project defines 3 classes, Rover, Position and Grid.  The program asks the user
for a multiline input, using the first line to create a Grid class object, then it iterates through
each line to feed commands to a Rover object to be created and added to a Rover class list for every 2 lines of commands.
The Rover class object reads in the commands and sends each character, out of "L, R, M" to a Position class
field which handles the logic for moving or turning the rover.

After iterating through all the lines of input, the program prints out the current positions and direction
of each Rover class in the list in order.

The code accounts for the following assumptions:
That there will be invalid input given for the Grid or Rover objects.  For Rovers given invalid input, the program
will output that invalid input was given for that rover class.

That a Rover could go out of bounds of the grid.  In this scenario, it will output that the rover had stopped
at a specific position and direction before going out of bounds and that it had

Included in the solution is a Unit Test project, using the XUnit framework, to verify the functionality
of the Rover, Position, and Grid class code.