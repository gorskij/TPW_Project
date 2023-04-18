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

            foreach(var ballHandler in _simulationLogic.BallHandlerCollection)
            {
                BallModelCollection.Add(new BallModel(ballHandler.Ball.X, ballHandler.Ball.Y, "Red", ballHandler.Ball.Radius));
            }
        }

        public override void Start()
        {
            _timer = new Timer(Update, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(16));
            
        }

        private void Update(object? state)
        {
            _simulationLogic.Update();
            UpdateBalls();
        }

        private void UpdateBalls()
        {
            for(int i = 0; i < BallModelCollection.Count; i++)
            {
                BallModelCollection[i].X = _simulationLogic.BallHandlerCollection[i].Ball.X;
                BallModelCollection[i].Y = _simulationLogic.BallHandlerCollection[i].Ball.Y;
            }
        }

        public override void Stop()
        {
            BallModelCollection.Clear();
            Dispose();
        }

        public override void Dispose()
        {
            _timer.Dispose();
        }
    }
}
