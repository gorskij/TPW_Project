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
    }
}
