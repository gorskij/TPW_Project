using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ISimulationLogic
    {
        public void Start();
        public List<BallModel> GenerateBalls(int ammoutOfBalls, int width, int height);
        public void Stop();
    }
}
