using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class AbstractCircle
    {
        public int Radius { get; internal set; }
        public Vector2 Position { get; internal set; }
        public Vector2 Speed { get; internal set; }
        public abstract event PropertyChangedEventHandler? PropertyChanged;


        public static AbstractCircle CreateCircle(Vector2 position)
        {
            return new Circle(position);
        }

        public abstract void ChangeDirectionX();
        public abstract void ChangeDirectionY();
        internal abstract void MoveCircle(Stopwatch timer);
    }
}
