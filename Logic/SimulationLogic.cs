using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SimulationLogic : ISimulationLogic
    {
        private readonly IBallCollectionManager _ballCollectionManager;
        private readonly Random _random = new();

        public SimulationLogic()
        {
            _ballCollectionManager = new BallCollectionManager();
        }
        public void Start()
        {

            _ballCollectionManager.Get()[1].X = 0;

            _ballCollectionManager.Get()[1].Y = 0;

        }

        public IBallCollectionManager BallCollectionManager
        {
            get { return _ballCollectionManager; }
        }

        public List<BallModel> GenerateBalls(int ammountOfBalls, int width, int height)
        {
            double radius = 15;
            double x, y;
            for (int i = 0; i < ammountOfBalls; i++)
            {
                x = _random.Next(30, width - 60);
                y = _random.Next(30, height - 60);
                BallModel ball = new(x,y,"Red",radius);
                _ballCollectionManager.Add(ball);
            }
            return _ballCollectionManager.Get();
        }

        private void _createThreads()
        {
            List<BallModel> balls = _ballCollectionManager.Get().ToList();
        }

        private void _stopThreads()
        {

        }

        public void Stop()
        {
            _ballCollectionManager.Clear();
        }
    }
}
