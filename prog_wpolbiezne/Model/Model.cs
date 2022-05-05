using Logic;
using System.Collections.ObjectModel;

namespace Model
{
    public class Board
    {
        public Board(double canvasWidth, double canvasHeight, LogicAbstractAPI? logicAPI = null)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            LogicAPI = logicAPI ?? LogicAbstractAPI.Create();
        }

        public ObservableCollection<Circle> GetStartingCirclePositions()
        {
            Animating = true;
            return LogicAPI.CreateCircles(5, _canvasWidth, _canvasHeight);
        }

        public ObservableCollection<Circle> MoveCircle(ObservableCollection<Circle> circles)
        {
            return LogicAPI.UpdatePositions(_canvasWidth, _canvasHeight, circles);
        }

        private bool _animating;

        public bool Animating
        {
            get => _animating; set => _animating = value;
        }

        private readonly double _canvasWidth;

        private readonly double _canvasHeight;

        private readonly LogicAbstractAPI? LogicAPI = default;
    }
}
