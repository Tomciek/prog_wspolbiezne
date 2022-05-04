namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI Create()
        {
            return new DataAPI();
        }

        public abstract void Connect();
    }
}