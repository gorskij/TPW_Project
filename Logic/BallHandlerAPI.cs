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
        public abstract void MoveBall();
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
        public override BallAPI Ball { get { return _ball; } }

        public override void MoveBall()
        {
            _ball.X += _ball.VelX;
            _ball.Y += _ball.VelY;
        }
    }
}
