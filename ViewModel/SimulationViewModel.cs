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

        public SimulationViewModel()
        {
            IncrementBallNumberCommand = new RelayCommand(IncrementBallNumber);
            SubtractBallNumberCommand = new RelayCommand(SubtractBallNumber);
        }

        public ICommand IncrementBallNumberCommand { get; }
        public ICommand SubtractBallNumberCommand { get; }

        public int NumberOfBalls
        {
            get { return _numberOfBalls; }
            set
            {
                _numberOfBalls = value;
                OnPropertyChanged(nameof(NumberOfBalls));
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
    }
}
