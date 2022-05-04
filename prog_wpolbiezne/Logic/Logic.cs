using Data;

namespace Logic
{
    public class Circle
    {
        private int x;
        private int y;
        private readonly int r;
        private int speedX;
        private int speedY;

        public Circle(int x, int y, int r)
        {
            Random random = new Random();
            this.x = x;
            this.y = y;
            this.r = r;
            if (speedX == 0)
            {
                this.speedX = random.Next();
            }
            if (speedY == 0)
            {
                this.speedY = random.Next();
            }
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

        public int GetSpeedX()
        {
            return speedX;
        }

        public int GetSpeedY()
        {
            return speedY;
        }

        public void SetSpeedX(int speedX)
        {
            this.speedX = speedX;
        }

        public void SetSpeedY(int speedY)
        {
            this.speedY = speedY;
        }
    }
}
