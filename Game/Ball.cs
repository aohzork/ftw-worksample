using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum BallTypes
    {
        Win = 1,
        ExraPick = 2,
        NoWin = 3,
    }

    public class Ball
    {
        public BallTypes Type { get; set; }
    }
}
