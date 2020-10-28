namespace PacktLibrary
{
    public class DisplacementVector
    {
        public int X;
        public int Y;

        public DisplacementVector(int initX, int initY)
        {
            X = initX;
            Y = initY;
        }

        public static DisplacementVector operator +(DisplacementVector v1, DisplacementVector v2)
        {
            return new DisplacementVector(
                v1.X + v2.X,
                v1.Y + v2.Y
            );
        }
    }
}