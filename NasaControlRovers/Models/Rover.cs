using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaControlRovers.Models
{
    public class Rover
    {
        private Position _startPosition;
        private Position _currentPosition;
        private Grid _grid;
        private bool _invalidInput;
        private readonly List<string> compass = new() { "N", "W", "S", "E" };
        private string _inputError;

        public Rover(Grid grid, string position)
        {
            _grid = grid;
            _invalidInput = false;

            List<string> movements = position.Split(" ").ToList();
            if (movements.Count == 3 && int.TryParse(movements[0], out int xAxis) && int.TryParse(movements[1], out int yAxis) && compass.Contains(movements[2]))
            {
                _startPosition = new Position(xAxis, yAxis, movements[2]);
                _currentPosition = _startPosition;
            }
            else
            {
                _invalidInput = true;
                _inputError = "Invalid position was given";
            }
        }

        public void MoveRover(string instructions)
        {
            if (!_invalidInput)
            {
                // iterate through each character and use a switch case to check for
                // expected characters "L, R, and M".  L and R represent 90 degree turns, updating the direction the rover is facing
                try
                {
                    foreach (var movement in instructions)
                    {
                        if (_invalidInput)
                        {
                            return;
                        }
                        var previousPosition = new Position(_currentPosition.XAxis, _currentPosition.YAxis, _currentPosition.Direction);
                        _currentPosition.UpdatePosition(movement);
                        if (_grid.isOutOfBounds(_currentPosition))
                        {
                            SetIsOutOfBounds(true);
                            _currentPosition.XAxis = previousPosition.XAxis;
                            _currentPosition.YAxis = previousPosition.YAxis;
                            return;
                        }
                    }
                }
                catch
                {
                    _invalidInput = true;
                    _inputError = "invalid instructions were given";
                }
            }
        }

        public string CurrentPosition()
        {
            if (!_invalidInput)
            {
                return _currentPosition.CurrentPosition();
            }
            return _inputError;
        }

        public void SetIsOutOfBounds(bool outOfBounds)
        {
            _currentPosition.SetIsOutOfBounds(outOfBounds);
        }
    }
}
