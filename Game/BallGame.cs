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
        private const int _costOfNewRound = 10;
        private const int _creditsOnWin = 20;

        private List<IBall> _balls;
        public BallGame(List<IBall> balls)
        {
            _balls = balls;
        }

        public void NewSession(Player player)
        {
            int wonCredits = 0, lostCredits = 0;
            var rnd = new Random();
            var isPlaying = true;
            var input = "";

            while (isPlaying)
            {
                if (player.CanPlayRound(_costOfNewRound))
                {
                    var result = PlayRound(player, lostCredits, rnd);
                    while (result == 3)
                    {
                        Console.WriteLine("Congratulations! You won an extra pick!");
                        result = NewRound(rnd);
                    }

                    input = ResultFeedback(result, player, wonCredits);

                    if (input.ToLower() == "n")
                    {
                        EndSession(wonCredits, lostCredits);
                        isPlaying = false;
                    }
                }

                input = "";
            }
        }

        private int PlayRound(Player player, int lostCredits, Random rnd)
        {
            player.SubtractCredits(_costOfNewRound);
            lostCredits += _costOfNewRound;
            Console.WriteLine("You pick a new ball. Let's see the result...");
            return NewRound(rnd);
        }

        private string ResultFeedback(int result, Player player, int winAmount)
        {  
            switch (result)
            {
                case 1:
                    Console.WriteLine("You Won the round!");
                    player.AddCredits(_creditsOnWin);
                    winAmount += _creditsOnWin;
                    break;
                case 2:
                    Console.WriteLine("Too bad. you Lost the round! But dont give up yet");
                    break;
            }

            Console.Write("Would you like to play again? Y/N: ");
            return Console.ReadLine();
        }

        void EndSession(int totalWonCredits, int totalLostCredits )
        {
            Console.WriteLine($"Total credits won: {totalWonCredits}");
            Console.WriteLine($"Total credits lost: {totalLostCredits}");
            Console.WriteLine($"Net amount lost/won {totalWonCredits-totalLostCredits}");
            Console.WriteLine("");

            var RTP = Math.Round(((double)totalWonCredits / totalLostCredits) * 100,2);

            Console.WriteLine($"RTP Value: {RTP}");
        }

        private int NewRound(Random rnd)
        {
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
