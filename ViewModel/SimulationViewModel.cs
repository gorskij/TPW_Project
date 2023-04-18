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
        private SimulationModelAPI _simulationModel;
        private int _numberOfBalls = 5;
        private bool _isStartEnabled = true;
        private bool _isStopEnabled = false;
        private ObservableCollection<BallModel> _ballModelCollection = new();

        public SimulationViewModel()
        {
            _simulationModel = SimulationModelAPI.CreateSimulationModel(800, 650);
            IncrementBallNumberCommand = new RelayCommand(IncrementBallNumber);
            SubtractBallNumberCommand = new RelayCommand(SubtractBallNumber);
            StartCommand = new RelayCommand(Start);
            StopCommand = new RelayCommand(Stop);
        }

        public ICommand IncrementBallNumberCommand { get; }
        public ICommand SubtractBallNumberCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand StartCommand { get; }

        public ObservableCollection<BallModel> BallModelCollection
        {
            get { return _ballModelCollection; }
            set
            {
                _ballModelCollection = value;
                OnPropertyChanged(nameof(BallModelCollection));
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

            _simulationModel.GenerateBalls(_numberOfBalls);
            foreach (BallModel ball in _simulationModel.BallModelCollection)
            {
                _ballModelCollection.Add(ball);
            }
            _simulationModel.Start();
        }

        public void Stop()
        {
            IsStopEnabled = false;
            IsStartEnabled = true;
            BallModelCollection.Clear();

        }
    }
}
