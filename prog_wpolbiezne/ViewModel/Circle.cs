using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ModelCircle : ViewModel
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Radius { get; set; }

        public String Color { get; set; }


        public ModelCircle(double x, double y, double r, String color)
        {
            this.X = x;
            this.Y = y;
            this.Radius = r;
            this.Color = color;
        }

        public void Update(Object obj, PropertyChangedEventArgs events)
        {
            Logic.LogicCircle circle = (Logic.LogicCircle)obj;
            X = circle.X;
            Y = circle.Y;
        }
    }
}
