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
        private static Collection<LogicCircle> circlesCollection = new();
        private static double height;
        private static double width;

        public LogicClass(DataAbstractAPI dataLayer)
        {
            DataLayer = dataLayer;
        }

        public override ObservableCollection<LogicCircle> CreateCircles(int numberOfCircles, double poolWidth, double poolHeight)
        {
            List<Circle> circles = new();
            ObservableCollection<LogicCircle> logicCircles = new();
            DataLayer.CreatePoolWithBalls(numberOfCircles, poolWidth, poolHeight);
            height = DataLayer.GetPoolHeight();
            width = DataLayer.GetPoolWidth();
            circles = DataLayer.GetCircles();
            foreach (Circle c in circles)
            {
                LogicCircle logicCircle = new LogicCircle(c);
                c.PropertyChanged += logicCircle.Update!;
                circlesCollection.Add(logicCircle);
                logicCircles.Add(logicCircle);
            }
            return logicCircles;
        }

        private static bool CirclesCollision(LogicCircle circle)
        {
            foreach (LogicCircle c in circlesCollection)
            {
                double distance = Math.Ceiling(Math.Sqrt(Math.Pow((c.GetX() - circle.GetX()), 2) + Math.Pow((c.GetY() - circle.GetY()), 2)));
                if (c != circle && distance <= (c.GetRadius() + circle.GetRadius()) && checkCircleBoundary(circle))
                {
                    circle.ChangeXDirection();
                    circle.ChangeYDirection();
                    return true;
                }
            }
            return false;
        }

        public static void UpdateCircleSpeed(LogicCircle circle)
        {
            if (circle.GetY() - circle.GetRadius() <= 0 || circle.GetY() + circle.GetRadius() >= height)
            {
                circle.ChangeYDirection();
            }
            if (circle.GetX() + circle.GetRadius() >= width || circle.GetX() - circle.GetRadius() <= 0)
            {
                circle.ChangeXDirection();
            }
        }
        private static bool checkCircleBoundary(LogicCircle circle)
        {
            return circle.GetY() - circle.GetRadius() <= 0 || circle.GetX() + circle.GetRadius() >= width || circle.GetY() + circle.GetRadius() >= height || circle.GetX() - circle.GetRadius() <= 0 ? false : true;
        }

        public override void CheckCollisionsWithBorders(Logic.LogicCircle cirle)
        {
            UpdateCircleSpeed(cirle);
        }

        public override void CheckCollisionsWithCircles(Logic.LogicCircle cirle)
        {
            CirclesCollision(cirle);
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
    }
}
