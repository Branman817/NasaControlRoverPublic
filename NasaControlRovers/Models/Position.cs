using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaControlRovers.Models
{
    public class Position
    {
        public int XAxis { get; set; }
        public int YAxis { get; set; }
        public string Direction { get; set; }

        private bool _isOutOfBounds;

        private readonly List<string> compass = new(){ "N", "W", "S", "E" };

        public Position(int x, int y, string direction)
        {
            XAxis = x;
            YAxis = y;
            Direction = direction;
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
            var index = compass.IndexOf(Direction);
            switch (turnDirection)
            {
                case -1:
                    if(index - 1 < 0)
                    {
                        Direction = compass[3];
                    }
                    else
                    {
                        Direction = compass[index - 1];
                    }
                    break;
                case 1:
                    if (index + 1 > 3)
                    {
                        Direction = compass[0];
                    }
                    else
                    {
                        Direction = compass[index + 1];
                    }
                    break;
            }
        }

        private void Move()
        {
            switch(Direction)
            {
                case "N":
                    YAxis += 1;
                    break;
                case "W":
                    XAxis -= 1;
                    break;
                case "S":
                    YAxis -= 1;
                    break;
                case "E":
                    XAxis += 1;
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
            return $"{XAxis} {YAxis} {Direction}" + append;
        }
    }
}
