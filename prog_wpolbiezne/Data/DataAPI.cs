using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataAPI : DataAbstractAPI
    {
        private Pool pool;

        public override void Connect()
        {
            throw new NotImplementedException();
        }

        public override void CreatePoolWithBalls(int amount, double widthOfCanvas, double heightOfCanvas)
        {
            this.pool = new Pool(amount, widthOfCanvas, heightOfCanvas);
        }

        public override List<Circle> GetCircles()
        {
            return pool.GetCircles();
        }

        public override void InterruptThreads()
        {
            pool.InterruptThreads();
        }

        public override void StartThreads()
        {
            pool.StartThreads();
        }

        public override double GetPoolHeight()
        {
            return pool.GetPoolHeight();
        }

        public override double GetPoolWidth()
        {
            return pool.GetPoolWidth();
        }
    }
}
