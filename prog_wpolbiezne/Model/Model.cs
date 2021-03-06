using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public class Board
    {

        private readonly double _canvasWidth;

        private readonly double _canvasHeight;

        private readonly LogicAbstractAPI? LogicAPI = default;

        private bool _animating;

        public Board(double canvasWidth, double canvasHeight, LogicAbstractAPI? logicAPI = null)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            LogicAPI = logicAPI ?? LogicAbstractAPI.Create();
        }

        public ObservableCollection<AbstractLogicCircle> GetStartingCirclePositions(int circleCount)
        {
            Animating = true;
            return LogicAPI.CreateCircles(circleCount, _canvasWidth, _canvasHeight);
        }

        public void InterruptThreads()
        {
            LogicAPI.InterruptThreads();
        }

        public void StartThreads()
        {
            LogicAPI.StartThreads();
        }

        public bool Animating
        {
            get => _animating; set => _animating = value;
        }

    }
}
