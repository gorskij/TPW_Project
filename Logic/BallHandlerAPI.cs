using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class BallHandlerAPI
    {
        public abstract List<BallAPI> BallCollection { get; }
        
        public abstract void MoveBall(BallAPI ball);
        public abstract void CheckCollision(BallAPI mainBall, BallAPI ball);
        public static BallHandlerAPI CreateBallHandler(WindowAPI window)
        {
            return new BallHandler(window);
        }
    }

    internal class BallHandler : BallHandlerAPI
    {
        private WindowAPI _window;

        public BallHandler(WindowAPI window)
        {
            _window = window;
        }
        public override List<BallAPI> BallCollection { get; } = new List<BallAPI>();

        public override void MoveBall(BallAPI ball)
        {
            if (ball.X + ball.Diameter+ball.Radius-4 >= _window.Width) ball.VelX *= -1;
            if (ball.Y + ball.Diameter+ball.Radius-5 >= _window.Height) ball.VelY *= -1;
            if (ball.X < 0) ball.VelX *= -1;
            if (ball.Y < 0) ball.VelY *= -1;
            ball.X += ball.VelX;
            ball.Y += ball.VelY;
        }

        public override void CheckCollision(BallAPI mainBall, BallAPI ball)
        {
            double distance;

            distance = Math.Sqrt(Math.Pow(mainBall.X + mainBall.VelX - (ball.X + ball.VelX), 2) + Math.Pow(mainBall.Y + mainBall.VelY - (ball.Y + ball.VelY), 2));
            if (distance <= mainBall.Radius + ball.Radius)
            {
                double nx = (ball.X + ball.VelX - (mainBall.X + mainBall.VelX)) / distance;
                double ny = (ball.Y + ball.VelY - (mainBall.Y + mainBall.VelY)) / distance;

                // oblicz składowe prędkości wzdłuż wektora normalnego
                double v1n = mainBall.VelX * nx + mainBall.VelY * ny;
                double v2n = ball.VelX * nx + ball.VelY * ny;

                // oblicz składowe prędkości wzdłuż wektora stycznego
                double v1t = mainBall.VelX * ny - mainBall.VelY * nx;
                double v2t = ball.VelX * ny - ball.VelY * nx;

                // oblicz nowe prędkości końcowe na podstawie zasad zachowania pędu i energii kinetycznej
                double m1 = mainBall.Mass;
                double m2 = ball.Mass;
                double v1n_after = (v1n * (m1 - m2) + 2 * m2 * v2n) / (m1 + m2);
                double v2n_after = (v2n * (m2 - m1) + 2 * m1 * v1n) / (m1 + m2);

                // ustaw nowe prędkości końcowe
                mainBall.VelX = v1n_after * nx + v1t * ny;
                mainBall.VelY = v1n_after * ny - v1t * nx;
                ball.VelX = v2n_after * nx + v2t * ny;
                ball.VelY = v2n_after * ny - v2t * nx;

                // unikaj przenikania kul poprzez przesunięcie ich na skraj kolidujących
                distance = Math.Sqrt(Math.Pow(mainBall.X - ball.X, 2) + Math.Pow(mainBall.Y - ball.Y, 2));
                double overlap = mainBall.Radius + ball.Radius - distance;
                mainBall.X -= overlap / 2 * nx;
                mainBall.Y -= overlap / 2 * ny;
                ball.X += overlap / 2 * nx;
                ball.Y += overlap / 2 * ny;
            }
            
        }
    }
}
