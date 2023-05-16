using Data;
using Logic;

namespace LogicTests
{
    [TestClass]
    public class SimulationLogicTest
    {
        [TestMethod]
        public void GenerateBallsTest()
        {
            SimulationLogicAPI simulationLogicApi = SimulationLogicAPI.CreateSimulationLogic(800, 600);
            
            simulationLogicApi.GenerateBalls(10);

            Assert.AreEqual(simulationLogicApi.BallHandler.BallCollection.Count, 10);
        }
        
        [TestMethod]
        public void StopTest()
        {
            SimulationLogicAPI simulationLogicApi = SimulationLogicAPI.CreateSimulationLogic(800, 600);
            
            simulationLogicApi.GenerateBalls(10);
            simulationLogicApi.Stop();
            Assert.AreEqual(simulationLogicApi.BallHandler.BallCollection.Count, 0);
        }
    }
}