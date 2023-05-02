using Data;

namespace Logic
{
    public abstract class SimulationLogicAPI
    {
        public abstract BallHandlerAPI BallHandler  { get; }
        public abstract void GenerateBalls(int numberOfBalls);
        public abstract void Start();
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
        private BallHandlerAPI _ballHandler;
        private bool _stopThreads = false;

        public SimulationLogic(int width, int height)
        {
            _window = WindowAPI.CreateWindow(width, height);
            _ballHandler = BallHandlerAPI.CreateBallHandler(_window);

        }

        public override BallHandlerAPI BallHandler => _ballHandler;

        public override void GenerateBalls(int numberOfBalls)
        {
            BallAPI ball;
            int x;
            int y;
            int radius = 20;
            for (int i = 0; i < numberOfBalls; i++)
            {
                x = _random.Next(radius, _window.Width - (radius * 3));
                y = _random.Next(radius, _window.Height - (radius * 3));
                ball = BallAPI.CreateBall(x, y, radius);
                _ballHandler.BallCollection.Add(ball);
            }
        }


        public override void Start()
        {
            _stopThreads = false;
            foreach (BallAPI ball in _ballHandler.BallCollection)
            {
                Thread thread = new(() =>
                {
                    while (!_stopThreads)
                    {
                        _ballHandler.MoveBall(ball);
                        Thread.Sleep(16);
                    }
                });
                thread.Start();
            }
        }


        public override void Stop()
        {
            _stopThreads = true;
            BallHandler.BallCollection.Clear();
        }
    }

}
