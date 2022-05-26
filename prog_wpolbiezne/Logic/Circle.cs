using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicCircle : INotifyPropertyChanged
    {
        private double _x;
        private double _y;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LogicCircle(Data.Circle c)
        {
            circle = c;
        }

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Data.Circle cirlce = (Data.Circle)s;
            X = circle.XPos;
            Y = circle.YPos;
            LogicAbstractAPI.Create().CheckCollisionsWithBorders(this);
            LogicAbstractAPI.Create().CheckCollisionsWithCircles(this);
        }

        private readonly Data.Circle circle;

        public void ChangeXDirection()
        {
            circle.ChangeDirectionX();
        }

        public void ChangeYDirection()
        {
            circle.ChangeDirectionY();
        }

        public double GetX()
        {
            return X;
        }

        public double GetY()
        {
            return Y;
        }

        public double GetRadius()
        {
            return circle.Radius;
        }

        public String GetColor()
        {
            return circle.Color;
        }

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }
        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }
    }
}
