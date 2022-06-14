using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicCircle : AbstractLogicCircle, INotifyPropertyChanged
    {
        public override event PropertyChangedEventHandler? PropertyChanged;
        private Vector2 _position;
        private readonly Data.AbstractCircle circle;

        public LogicCircle(Data.AbstractCircle c)
        {
            this.circle = c;
        }

        public override void ChangeXDirection()
        {
            circle.ChangeDirectionX();
        }

        public override void ChangeYDirection()
        {
            circle.ChangeDirectionY();
        }

        public override double GetRadius()
        {
            return circle.Radius;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public override Vector2 Postion
        {
            get => _position;
            internal set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public override void Update(Object s, PropertyChangedEventArgs e)
        {
            Data.AbstractCircle cir = (Data.AbstractCircle)s;
            Postion = cir.Position;
            LogicAbstractAPI.Create().CheckCollisionsWithBorders(this);
            LogicAbstractAPI.Create().CheckCollisionsWithCircles(this);
        }
    }
}
