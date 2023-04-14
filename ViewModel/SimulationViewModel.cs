using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class SimulationViewModel : ViewModelBase
    {

        private int _numberOfBalls = 5;
        private bool _isRunning = false;
        private bool _isStartEnabled = true;
        private bool _isStopEnabled = false;

        public SimulationViewModel()
        {
            IncrementBallNumberCommand = new RelayCommand(IncrementBallNumber);
            SubtractBallNumberCommand = new RelayCommand(SubtractBallNumber);
            StartCommand = new RelayCommand(Start);
            StopCommand = new RelayCommand(Stop);
        }

        public ICommand IncrementBallNumberCommand { get; }
        public ICommand SubtractBallNumberCommand { get; }
        public ICommand StopCommand { get; }
        public ICommand StartCommand { get; }

        public bool IsRunning
        {
            get { return _isRunning; }
            set {
                if (value == _isRunning) return;
                _isRunning = value;
                OnPropertyChanged(nameof(IsRunning));
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
            IsRunning = true;
        }

        public void Stop()
        {
            IsStopEnabled = false;
            IsStartEnabled = true;
            IsRunning = false;
        }
    }
}
