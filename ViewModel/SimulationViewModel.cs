using Data;
using GalaSoft.MvvmLight.Command;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SimulationViewModel : ViewModelBase
    {

        private int _numberOfBalls = 5;
        private bool _isStartEnabled = true;
        private bool _isStopEnabled = false;
        private readonly ISimulationLogic _simulationLogic;
        private ObservableCollection<BallModel> _ballCollection = new();

        public SimulationViewModel()
        {
            _simulationLogic = new SimulationLogic();
            IncrementBallNumberCommand = new RelayCommand(IncrementBallNumber);
            SubtractBallNumberCommand = new RelayCommand(SubtractBallNumber);
            StartCommand = new RelayCommand(Start);
            StopCommand = new RelayCommand(Stop);
        }

        public ICommand IncrementBallNumberCommand { get; }
        public ICommand SubtractBallNumberCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand StartCommand { get; }

        public ObservableCollection<BallModel> BallCollection
        {
            get { return _ballCollection; }
            set
            {
                _ballCollection = value;
                OnPropertyChanged(nameof(BallCollection));
            }
        }

        public int NumberOfBalls
        {
            get { return _numberOfBalls; }
            set
            {
                _numberOfBalls = value;
                OnPropertyChanged(nameof(NumberOfBalls));
            }
        }

        public bool IsStartEnabled
        {
            get { return _isStartEnabled; }
            set
            {
                if (value == _isStartEnabled) return;
                _isStartEnabled = value;
                OnPropertyChanged(nameof(IsStartEnabled));
            }
        }

        public bool IsStopEnabled
        {
            get { return _isStopEnabled; }
            set
            {
                if (value == _isStopEnabled) return;
                _isStopEnabled = value;
                OnPropertyChanged(nameof(IsStopEnabled));
            }
        }

        private void IncrementBallNumber()
        {
            NumberOfBalls++;
        }

        private void SubtractBallNumber()
        {
            NumberOfBalls--;
        }

        public void Start()
        {
            IsStartEnabled = false;
            IsStopEnabled = true;

            List<BallModel> BallList = _simulationLogic.GenerateBalls(NumberOfBalls, 800, 650);
            foreach (BallModel ball in BallList)
            {
                _ballCollection.Add(ball);
            }

            _simulationLogic.Start();
           // BallModel ball = new(100, 100, "Red", 5);

         //   BallCollection.Add(ball);
        }

        public void Stop()
        {
            IsStopEnabled = false;
            IsStartEnabled = true;
            _simulationLogic.Stop();
            BallCollection.Clear();

        }
    }
}
