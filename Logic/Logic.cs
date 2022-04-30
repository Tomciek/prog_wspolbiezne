using Data;

namespace Logic
{
    public class Circle
    {
        private int x;
        private int y;
        private readonly int r;

        public Circle(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public int GetR()
        {
            return r;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }
    }
    public static class CircleManager
    {
        public static Circle CreateCircle(int minX, int maxX, int minY, int maxY)
        {
            Random random = new Random();
            return new Circle(random.Next(minX, maxX), random.Next(minY,maxY), 10);
        }

        public static void MoveCircle(Circle circle, int newX, int newY)
        {
            Random random = new Random();
            circle.SetX(random.Next(newX));
            circle.SetY(random.Next(newY));
        }
    }
}
