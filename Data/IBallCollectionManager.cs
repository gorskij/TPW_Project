using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBallCollectionManager
    {
        List<BallModel> Get();
        void Add(BallModel ball);
        void Clear();
    }
}
