using Logic;

namespace Model
{
    public abstract class SimulationModelAPI
    {
        public abstract void Start();
        public abstract void Stop();
        public abstract List<BallModel> BallModelCollection { get; }
        public abstract void GenerateBalls(int numberOfBalls);
        public abstract void Dispose();
        public static SimulationModelAPI CreateSimulationModel(int width, int height) 
        { 
            return new SimulationModel(width, height);
        }
    }

    internal class SimulationModel : SimulationModelAPI, IDisposable
    {
        private readonly SimulationLogicAPI _simulationLogic;
        private Timer? _timer;

        public SimulationModel(int width, int height)
        {
            _simulationLogic = SimulationLogicAPI.CreateSimulationLogic(width, height);
        }
        public override List<BallModel> BallModelCollection { get; } = new List<BallModel>();

        public override void GenerateBalls(int numberOfBalls)
        {
            _simulationLogic.GenerateBalls(numberOfBalls);
            List<string> colors = new() { "Red", "Green", "Blue", "Pink", "Yellow", "Purple", "Aqua", "Orange", "Brown", "DeepPink", "GreenYellow" };
            Random random = new();

            foreach (var ball in _simulationLogic.BallHandler.BallCollection)
            {
                BallModelCollection.Add(new BallModel(ball.X, ball.Y, colors[random.Next(0, colors.Count)], ball.Radius));
            }
        }

        public override void Start()
        {
            _simulationLogic.Start();
            Task.Run(() =>
            {
                _timer = new Timer(Update, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(16));
            });
        }

        private void Update(object? state)
        {
            UpdateBalls();
        }

        private void UpdateBalls()
        {
            for(int i = 0; i < BallModelCollection.Count; i++)
            {
                BallModelCollection[i].X = _simulationLogic.BallHandler.BallCollection[i].X - BallModelCollection[i].Radius;
                BallModelCollection[i].Y = _simulationLogic.BallHandler.BallCollection[i].Y - BallModelCollection[i].Radius;
            }
        }

        public override void Stop()
        {
            Dispose();
            _simulationLogic.Stop();
            BallModelCollection.Clear();
        }

        public override void Dispose()
        {
            _timer.Dispose();
        }
    }
}
