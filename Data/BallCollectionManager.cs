using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BallCollectionManager : IBallCollectionManager
    {
        private List<BallModel> _balls = new();
        public void Add(BallModel ball)
        {
            _balls.Add(ball);
        }

        public void Clear()
        {
            _balls.Clear();
        }

        public List<BallModel> Get()
        {
            return _balls;
        }
    }
}
