using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicAbstractAPI
    {
        public static LogicAbstractAPI Create(DataAbstractAPI? data = default)
        {
            return new LogicAPI(data ?? DataAbstractAPI.Create());
        }

        public abstract ObservableCollection<Circle> CreateCircles(int numberOfCircles, double poolWidth, double poolHeight);
        public abstract ObservableCollection<Circle> UpdatePositions(double poolWidth, double poolHeight, ObservableCollection<Circle> circles);

        private class LogicAPI : LogicAbstractAPI
        {
            private readonly DataAbstractAPI DataLayer;
            public LogicAPI(DataAbstractAPI dataLayer)
            {
                dataLayer = dataLayer;
            }

            public override ObservableCollection<Circle> CreateCircles(int circleCountdouble, double poolWidth, double poolHeight)
            {
                ObservableCollection<Circle> circles = new ObservableCollection<Circle>();
                Random random = new Random();
                for (int i = 0; i < circles.Count; i++)
                {
                    Circle circle = new Circle(random.Next(5, 10), random.Next(20, (int)poolWidth - 20), random.Next(20, (int)poolHeight - 20));
                    circles.Add(circle);
                }
                return circles;
            }

            public override ObservableCollection<Circle> UpdatePositions(double poolWidth, double poolHeight, ObservableCollection<Circle> circles)
            {
                ObservableCollection<Circle> newCircles = new ObservableCollection<Circle>();
                foreach (Circle circle in circles)
                {
                    if (circle.GetX() + circle.GetR() + 1 > poolWidth || circle.GetX() - circle.GetR() - 1 < 0)
                    {
                        circle.SetSpeedX(-1 * circle.GetSpeedX());
                    }
                    if (circle.GetY() + circle.GetR() + 1 > poolHeight || circle.GetX() - circle.GetR() - 1 < 0)
                    {
                        circle.SetSpeedY(-1 * circle.GetSpeedY());
                    }

                    circle.SetX(circle.GetX() + circle.GetSpeedX());
                    circle.SetY(circle.GetY() + circle.GetSpeedY());
                    newCircles.Add(circle);
                }
                return newCircles;
            }
        }
    }
}
