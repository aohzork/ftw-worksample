﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum BallType
    {
        Win = 1,
        ExraPick = 2,
        NoWin = 3,
    }

    public class Ball : IBall
    {
        public BallType Type { get; set; }

        public IBall Clone(BallType type)
        {
            return new Ball { Type = type };
        }
    }
}
