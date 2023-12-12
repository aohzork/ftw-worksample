using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Gameplay
    {
        private List<IBall> _balls;

        public Gameplay(List<IBall> balls)
        { 
            _balls = balls;
        }

        public void Initialize(int winTypeAmnt, int noWinTypeAmnt, IBall ball, int extraPickAmnt = 0)
        {
            for(int i = 0; i < winTypeAmnt; i++)
            {
                _balls.Add(AddBall(ball, BallType.Win));
            }

            for(int i = 0;i < noWinTypeAmnt; i++)
            {
                _balls.Add(AddBall(ball, BallType.NoWin));
            }

            if(extraPickAmnt > 0)
            {
                for( int i = 0; i<extraPickAmnt; i++)
                {
                    _balls.Add(AddBall(ball, BallType.ExraPick));
                }
            }
        }

        private IBall AddBall(IBall ball, BallType type)
        {
            ball.Type = type;
            return ball;
        }

        public List<IBall> GetBalls()
        {
            return _balls;
        }
    }
}