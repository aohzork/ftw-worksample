namespace Game
{
    public class InitBallGamplay
    {
        private List<IBall> _balls = new List<IBall>();

        public InitBallGamplay(int winTypeAmnt, int noWinTypeAmnt, IBall ball, int extraPickAmnt = 0)
        {
            Initialize(winTypeAmnt, noWinTypeAmnt, ball, extraPickAmnt);
        }

        private void Initialize(int winTypeAmnt, int noWinTypeAmnt, IBall ball, int extraPickAmnt = 0)
        {
            for(int i = 0; i < winTypeAmnt; i++)
            {
                _balls.Add(ball.Clone(BallType.Win));
            }

            for(int j = 0; j < noWinTypeAmnt; j++)
            {
                _balls.Add(ball.Clone(BallType.NoWin));
            }

            if (extraPickAmnt > 0)
            {
                for( int k = 0; k<extraPickAmnt; k++)
                {
                    _balls.Add(ball.Clone(BallType.ExraPick));
                }
            }
        }

        public List<IBall> GetBalls()
        {
            return _balls;
        }
    }
}