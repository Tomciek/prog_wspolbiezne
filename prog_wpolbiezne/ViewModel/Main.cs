using Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ViewModel;

namespace VievModel
{
    public class ViewFull : ViewModel.ViewModel
    {
        public ViewFull()
        {
            _circles = new();
            WindowHeight = 640;
            WindowWidth = 1230;
            BoardModel = new Board(WindowWidth, WindowHeight);
            StartCommand = new CommandBase(() => Start());
            StopCommand = new CommandBase(() => Stop());
        }

        public static void Main(String[] args)
        {
            Console.WriteLine("Hello");
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
            Circles = BoardModel.GetStartingCirclePositions();
            while (BoardModel.Animating)
            {
                await Task.Delay(15);
                Circles = BoardModel.MoveCircle(_circles);
            }
        }

        private void Stop()
        {
            BoardModel.Animating = false;
        }

        private ObservableCollection<Logic.Circle> _circles;
        public ObservableCollection<Logic.Circle> Circles
        {
            get => _circles;
            set
            {
                _circles = value;
                OnPropertyChanged(nameof(Circles));
            }
        }
        public int WindowHeight { get; }
        public int WindowWidth { get; }

        public Board BoardModel { get; set; }
    }
}
