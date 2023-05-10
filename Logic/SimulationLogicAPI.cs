using Data;
using System.Threading;

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
        private List<Thread> _threads = new List<Thread>();

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
            int radius;
            for (int i = 0; i < numberOfBalls; i++)
            {
                radius = _random.Next(10, 20);
                do
                {
                    x = _random.Next(radius, _window.Width - (radius * 3));
                    y = _random.Next(radius, _window.Height - (radius * 3));
                } while (IsOverlaping(x, y, radius));

                ball = BallAPI.CreateBall(x, y, radius);
                _ballHandler.BallCollection.Add(ball);
            }
        }

        private bool IsOverlaping(int x, int y, int radius)
        {
            double distance;
            foreach (BallAPI ball in BallHandler.BallCollection)
            {
                distance = Math.Sqrt(Math.Pow(x - ball.X, 2) + Math.Pow(y - ball.Y, 2));
                if (distance <= radius + ball.Radius) return true;
            }
            return false;
        }
        public override void Start()
        {
            _stopThreads = false;
            Semaphore semaphore = new Semaphore(1, 1);
            foreach (BallAPI mainBall in _ballHandler.BallCollection)
            {
                Thread thread = new(() =>
                {
                    while (!_stopThreads)
                    {
                        semaphore.WaitOne();
                        if(_stopThreads)
                        {
                            semaphore.Release();
                            break;
                        }
                        foreach (BallAPI ball in _ballHandler.BallCollection)
                        {
                            if (ball == mainBall)
                            {
                                continue;
                            }
                            _ballHandler.CheckCollision(mainBall, ball);
                        }
                        _ballHandler.MoveBall(mainBall);
                        semaphore.Release();
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
