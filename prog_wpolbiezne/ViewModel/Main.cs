using Logic;
using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ViewModel;

namespace ViewModel
{
    public class ViewFull : ViewModel
    {
        public int WindowHeight { get; }
        public int WindowWidth { get; }
        public Board BoardModel { get; set; }

        public ViewFull()
        {
            viewModelCircles = new();
            //Wysokosc i szerokosc okienka z kulami
            WindowHeight = 480;
            WindowWidth = 800;

            BoardModel = new Board(WindowWidth, WindowHeight);
            StartCommand = new Commands(() => Start());
            StopCommand = new Commands(() => Stop());
        }

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }



        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private async void Start()
        {
            foreach (LogicCircle logicCircle in BoardModel.GetStartingCirclePositions(Count))
            {
                ModelCircle circle = new ModelCircle(logicCircle.GetX(), logicCircle.GetY(), logicCircle.GetRadius(), logicCircle.GetColor());
                viewModelCircles.Add(circle);
                logicCircle.PropertyChanged += circle.Update!;
            }
            BoardModel.StartThreads();
            while (BoardModel.Animating)
            {
                await Task.Delay(10);
                Circles = new ObservableCollection<ModelCircle>(viewModelCircles);
            }
        }

        private void Stop()
        {
            BoardModel.Animating = false;
            BoardModel.InterruptThreads();
            viewModelCircles.Clear();
        }

        private ObservableCollection<ModelCircle> viewModelCircles;
        public ObservableCollection<ModelCircle> Circles
        {
            get => viewModelCircles;
            set
            {
                viewModelCircles = value;
                OnPropertyChanged(nameof(Circles));
            }
        }
    }
}
