using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BallGame
    {
        private readonly int _costOfNewRound = 10;
        private readonly int _creditsOnWin = 20;

        private List<IBall> _balls;
        void GetBalls(List<IBall> balls)
        {
            _balls = balls;
        }

        void NewSession(Player player)
        {
            var wonCredits = 0;
            var lostCredits = 0;
            var canExtraPick = false;
            string input = "";
            var canPlay = player.CanPlayRound(_costOfNewRound);

            while(canPlay)
            {
                var result = 0;

                if (canExtraPick)
                {
                    result = NewRound();
                    canExtraPick = false;
                }
                else if (canPlay)
                {
                    player.SubtractCredits(_costOfNewRound);
                    lostCredits += _costOfNewRound;
                    result = NewRound();
                }

                input = ResultChecker(result, canExtraPick, player, wonCredits);

                if (input.ToLower() == "n")
                {
                    canPlay = false;
                    EndSession(wonCredits, lostCredits);
                }
            }
        }

        string ResultChecker(int result, bool canExtraPick, Player player, int winAmount)
        {
            var input = "";
            switch (result)
            {
                case 1:
                    Console.WriteLine("You Won the round!");
                    player.AddCredits(_creditsOnWin);
                    winAmount += _costOfNewRound;
                    Console.Write("Would you like to play again? Y/N: ");
                    input = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Too bad. you Lost the round! But dont give up yet. Try again?");
                    Console.Write("Y/N: ");
                    input = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Congrats!! You got got an Extra Pick!");
                    input = "Y";
                    canExtraPick = true;
                    break;
            }

            return input;
        }

        void EndSession(int totalWonCredits, int totalLostCredits )
        {
            Console.WriteLine($"Total credits won: {totalWonCredits}");
            Console.WriteLine($"Total credits lost: {totalLostCredits}");
            Console.WriteLine($"Net amount lost/won {totalWonCredits-totalLostCredits}");
            Console.WriteLine("");
            Console.WriteLine($"RTP Value: {(totalWonCredits / totalLostCredits) * 100} %");
        }

        //EndRound();

        public int NewRound()
        {
            var rnd = new Random();
            var ball = PickBall(rnd);

            switch (ball.Type)
            {
                case BallType.Win:
                    return 1;
                case BallType.NoWin:
                    return 2;
                case BallType.ExraPick:
                    return 3;
            }

            return 0;
        }

        IBall PickBall(Random rnd)
        {
            var index = rnd.Next(0, _balls.Count);
            return _balls[index];
        }
    }
}
