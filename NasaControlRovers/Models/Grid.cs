namespace NasaControlRovers.Models
{
    public class Grid
    {
        private int _xDimension;
        private int _yDimension;

        public Grid(int xDimension, int yDimension)
        {
            _xDimension = xDimension;
            _yDimension = yDimension;
        }

        public bool isOutOfBounds(Position coordinates)
        {
            if(coordinates._xAxis > _xDimension || coordinates._yAxis > _yDimension)
            {
                return true;
            }
            else if(coordinates._xAxis < 0 || coordinates._yAxis < 0)
            {
                return true;
            }
            return false;
        }
    }
}
