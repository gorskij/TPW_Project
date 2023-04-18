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
        public abstract BallAPI Ball { get; }
        public abstract void MoveBall(int width, int height);
        public static BallHandlerAPI CreateBallHandler(BallAPI ball)
        {
            return new BallHandler(ball);
        }
    }

    internal class BallHandler : BallHandlerAPI
    {
        private readonly BallAPI _ball;

        public BallHandler(BallAPI ball)
        {
            _ball = ball;
        }
        public override BallAPI Ball => _ball;

        public override void MoveBall(int width, int height)
        {
            if (_ball.X + _ball.Diameter+_ball.Radius-4 >= width) _ball.VelX *= -1;
            if (_ball.Y + _ball.Diameter+_ball.Radius-5 >= height) _ball.VelY *= -1;
            if (_ball.X < 0) _ball.VelX *= -1;
            if (_ball.Y < 0) _ball.VelY *= -1;
            _ball.X += _ball.VelX;
            _ball.Y += _ball.VelY;
        }
    }
}
