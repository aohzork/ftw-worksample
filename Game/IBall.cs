﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IBall
    {
        BallType Type { get; set; }
        IBall Clone(BallType type);
    }
}
