namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI Create()
        {
            return new DataAPI();
        }

        public abstract void Connect();

        public abstract void CreatePoolWithBalls(int amount, double widthOfCanvas, double heightOfCanvas);

        public abstract List <Circle> GetCircles();

        public abstract void InterruptThreads();

        public abstract void StartThreads();

        public abstract double GetPoolWidth();

        public abstract double GetPoolHeight();
    }
}
