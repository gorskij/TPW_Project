using Data;

namespace Logic
{
    public abstract class SimulationLogicAPI
    {
        public abstract List<BallHandlerAPI> BallHandlerCollection { get; }

        public abstract void GenerateBalls(int numberOfBalls);
        public abstract void Update();
        public abstract void Stop();
        public static SimulationLogicAPI CreateSimulationLogic(int width, int height)
        {
            return new SimulationLogic(width, height);
        }
    }

    internal class SimulationLogic : SimulationLogicAPI
    {
        private readonly WindowAPI _window;
        private readonly Random _random = new();
        public SimulationLogic(int width, int height)
        {
            _window = WindowAPI.CreateWindow(width, height);
        }
        public override List<BallHandlerAPI> BallHandlerCollection { get; } = new List<BallHandlerAPI>();
        public override void GenerateBalls(int numberOfBalls)
        {
            BallAPI ball;
            BallHandlerAPI ballHandler;
            int x;
            int y;
            int radius = 20;
            for (int i = 0; i < numberOfBalls; i++)
            {
                x = _random.Next(radius, _window.Width - (radius * 3));
                y = _random.Next(radius, _window.Height - (radius * 3));
                ball = BallAPI.CreateBall(x, y, radius);
                ballHandler = BallHandlerAPI.CreateBallHandler(ball);
                BallHandlerCollection.Add(ballHandler);
            }
        }

        public override void Stop()
        {
            BallHandlerCollection.Clear();
        }

        public override void Update()
        {
            foreach(var ballHandler in  BallHandlerCollection)
            {
                ballHandler.MoveBall(_window.Width, _window.Height);
            }
        }
    }

}
