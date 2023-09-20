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
            if(coordinates.XAxis > _xDimension || coordinates.YAxis > _yDimension)
            {
                return true;
            }
            else if(coordinates.XAxis < 0 || coordinates.YAxis < 0)
            {
                return true;
            }
            return false;
        }
    }
}
