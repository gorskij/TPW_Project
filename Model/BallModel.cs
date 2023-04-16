using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        private double x;
        private double y;

        public event PropertyChangedEventHandler? PropertyChanged;

        public double Radius { get; }
        public double Diameter { get; }
        public string Color { get; }

        public BallModel(double x, double y, string color, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
            Diameter = radius *  2;
            Color = color;
        }

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        }
        public double Y
        { get { return y; }
            set 
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
