using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicClass : LogicAbstractAPI
    {
        private readonly DataAbstractAPI DataLayer;
        private static Collection<AbstractLogicCircle> circlesCollection = new();
        private static double height;
        private static double width;

        public LogicClass(DataAbstractAPI dataLayer)
        {
            DataLayer = dataLayer;
        }

        public override void CheckCollisionsWithBorders(Logic.AbstractLogicCircle circle)
        {
            UpdateCircleSpeed(circle);
        }

        public override void CheckCollisionsWithCircles(Logic.AbstractLogicCircle circle)
        {
            CirclesCollision(circle);
        }

        public override void InterruptThreads()
        {
            DataLayer.InterruptThreads();
            circlesCollection.Clear();
        }

        public override void StartThreads()
        {
            DataLayer.StartThreads();
        }

        public override ObservableCollection<AbstractLogicCircle> CreateCircles(int numberOfCircles, double poolWidth, double poolHeight)
        {
            List<AbstractCircle> circles = new();
            ObservableCollection<AbstractLogicCircle> logicCircles = new();
            DataLayer.CreatePoolWithBalls(numberOfCircles, poolWidth, poolHeight);
            height = DataLayer.GetPoolHeight();
            width = DataLayer.GetPoolWidth();
            circles = DataLayer.GetCircles();
            foreach (AbstractCircle c in circles)
            {
                AbstractLogicCircle logicCircle = AbstractLogicCircle.CreateCircle(c);
                c.PropertyChanged += logicCircle.Update!;
                circlesCollection.Add(logicCircle);
                logicCircles.Add(logicCircle);
            }
            return logicCircles;
        }

        private static bool CirclesCollision(AbstractLogicCircle circle)
        {
            foreach (AbstractLogicCircle c in circlesCollection)
            {
                double distance = Math.Ceiling(Math.Sqrt(Math.Pow((c.Postion.X - circle.Postion.X), 2) + Math.Pow((c.Postion.Y - circle.Postion.Y), 2)));
                if (c != circle && distance <= (c.GetRadius() + circle.GetRadius()) && checkCircleBoundary(circle))
                {
                    circle.ChangeXDirection();
                    circle.ChangeYDirection();
                    return true;
                }
            }
            return false;
        }

        public static void UpdateCircleSpeed(AbstractLogicCircle circle)
        {
            if (circle.Postion.Y - circle.GetRadius() <= 0 || circle.Postion.Y + circle.GetRadius() >= height)
            {
                circle.ChangeYDirection();
            }
            if (circle.Postion.X + circle.GetRadius() >= width || circle.Postion.X - circle.GetRadius() <= 0)
            {
                circle.ChangeXDirection();
            }
        }
        private static bool checkCircleBoundary(AbstractLogicCircle circle)
        {
            return circle.Postion.Y - circle.GetRadius() <= 0 || circle.Postion.X + circle.GetRadius() >= width || circle.Postion.Y + circle.GetRadius() >= height || circle.Postion.X - circle.GetRadius() <= 0 ? false : true;
        }
    }
}
