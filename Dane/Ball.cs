using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double speedX;
        private double speedY;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ball(double x, double y, double speedx, double speedy)
        {
            this.x = x;
            this.y = y;
            speedX = speedx;
            speedY = speedy;
        }

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }
        public double Y 
        { 
            get { return y; }
            set 
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }
        public double SpeedX { get {  return speedX; } set {  speedX = value; } }
        public double SpeedY { get {  return speedY; } set { speedY = value; } }
        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
