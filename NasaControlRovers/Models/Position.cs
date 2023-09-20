using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaControlRovers.Models
{
    public class Position
    {
        public int _xAxis;
        public int _yAxis;
        public string _direction;
        private bool _isOutOfBounds;

        private readonly List<string> compass = new(){ "N", "W", "S", "E" };

        public Position(int x, int y, string direction)
        {
            _xAxis = x;
            _yAxis = y;
            _direction = direction;
            _isOutOfBounds = false;
        }

        public void UpdatePosition(char movement)
        {
            switch(movement)
            {
                case 'L':
                    Turn(1);
                    break;
                case 'R':
                    Turn(-1);
                    break;
                case 'M':
                    Move();
                    break;
                default:
                    throw new Exception("Invalid input was entered");
            }
        }

        private void Turn(int turnDirection)
        {
            var index = compass.IndexOf(_direction);
            switch (turnDirection)
            {
                case -1:
                    if(index - 1 < 0)
                    {
                        _direction = compass[3];
                    }
                    else
                    {
                        _direction = compass[index - 1];
                    }
                    break;
                case 1:
                    if (index + 1 > 3)
                    {
                        _direction = compass[0];
                    }
                    else
                    {
                        _direction = compass[index + 1];
                    }
                    break;
            }
        }

        private void Move()
        {
            switch(_direction)
            {
                case "N":
                    _yAxis += 1;
                    break;
                case "W":
                    _xAxis -= 1;
                    break;
                case "S":
                    _yAxis -= 1;
                    break;
                case "E":
                    _xAxis += 1;
                    break;
            }
        }

        public void SetIsOutOfBounds(bool outOfBounds)
        {
            _isOutOfBounds = outOfBounds;
        }

        public string CurrentPosition()
        {
            string append = "";
            if(_isOutOfBounds)
            {
                append = " before going out of bounds of grid";
            }
            return $"{_xAxis} {_yAxis} {_direction}" + append;
        }
    }
}
