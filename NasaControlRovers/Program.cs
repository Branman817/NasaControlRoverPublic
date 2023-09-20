using NasaControlRovers.Models;
using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter NASA Rover instructions\nFirst line defines grid dimensions in the form of \"x y\"\nAfter the first line, every 2 lines controlls a separate rover\nWhen finished, press enter again to send instructions");
        string line;
        var inputs = new List<string>();
        while (!String.IsNullOrWhiteSpace(line = Console.ReadLine()))
        {
            if(!String.IsNullOrEmpty(line))
            {
                inputs.Add(line);
            }
        }

        var dimensions = inputs[0].ToString().Split(" ").ToList();
        try
        {
            if (!int.TryParse(dimensions[0], out int xValue) || !int.TryParse(dimensions[1], out int yValue) || dimensions.Count != 2)
            {
                Console.WriteLine("Invalid input for grid dimensions");
                return;
            }
        }
        catch
        {
            Console.WriteLine("Invalid input for grid dimensions");
            return;
        }

        var x = Convert.ToInt32(dimensions[0]);
        var y = Convert.ToInt32(dimensions[1]);

        var grid = new Grid(x, y);
        var rovers = new List<Rover>();

        inputs.RemoveAt(0);
        foreach (var input in inputs)
        {
            if (inputs.IndexOf(input) % 2 == 0)
            {
                rovers.Add(new Rover(grid, input));
            }
            else
            {
                rovers.Last().MoveRover(input);
            }
        }

        foreach (var rover in rovers)
        {
            Console.WriteLine(rover.CurrentPosition());
        }
    }
}