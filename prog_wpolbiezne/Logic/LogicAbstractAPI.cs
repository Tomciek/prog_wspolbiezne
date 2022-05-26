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
            return new LogicClass(data ?? DataAbstractAPI.Create());
        }

        public abstract ObservableCollection<LogicCircle> CreateCircles(int numberOfCircles, double poolWidth, double poolHeight);
        
        public abstract void InterruptThreads();

        public abstract void StartThreads();

        public abstract void CheckCollisionsWithBorders(LogicCircle cirle);

        public abstract void CheckCollisionsWithCircles(LogicCircle cirle);
    }
}
