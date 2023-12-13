using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BallGame : IGame
    {
        private const int CostOfNewRound = 10;
        private const int CreditsOnWin = 20;

        private List<IBall> _balls;
        private BILogger _bILogger = new BILogger();
        public BallGame(List<IBall> balls)
        {
            _balls = balls;
        }

        public void NewSession(Player player)
        {
            int wonCredits = 0, lostCredits = 0;
            var rnd = new Random();
            var isPlaying = true;

            while (isPlaying && player.CanPlayRound(CostOfNewRound))
            {
                var result = PlayRound(player, ref lostCredits, rnd);
                while (result == 3)
                {
                    Console.WriteLine("Congratulations! You won an extra pick!");
                    result = NewRound(rnd);
                }

                var input = ResultFeedback(result, player, ref wonCredits);

                if (input.ToLower() == "n")
                {
                    EndSession(wonCredits, lostCredits);
                    isPlaying = false;
                };
            }
        }

        public int PlayRound(Player player, ref int lostCredits, Random rnd)
        {
            player.SubtractCredits(CostOfNewRound);
            lostCredits += CostOfNewRound;
            Console.WriteLine("You pick a new ball. Let's see the result...");
            return NewRound(rnd);
        }

        public string ResultFeedback(int result, Player player, ref int winAmount)
        {  
            switch (result)
            {
                case 1:
                    Console.WriteLine("You Won the round!");
                    player.AddCredits(CreditsOnWin);
                    winAmount += CreditsOnWin;
                    break;
                case 2:
                    Console.WriteLine("Too bad. you Lost the round! But dont give up yet");
                    break;
            }

            Console.Write("Would you like to play again? Y/N: ");
            return ValidateInput(Console.ReadLine());
        }

        public string ValidateInput(string input)
        {

            if (String.IsNullOrEmpty(input) || (input.ToLower() != "y" && input.ToLower() != "n"))
            {
                Console.WriteLine("Sorry, cannot recognize the input, please try again");
                input = ValidateInput(Console.ReadLine());
            }

            return input;
        }

        public void EndSession(int totalWonCredits, int totalLostCredits )
        {
            Console.WriteLine($"Total credits won: {totalWonCredits}");
            Console.WriteLine($"Total credits lost: {totalLostCredits}");
            var netAmount = CalculateNetWinLoss(totalWonCredits,totalLostCredits);
            Console.WriteLine($"Net amount lost/won {netAmount}");
            Console.WriteLine("");

            var RTP = _bILogger.CalculateRTP(totalWonCredits, totalLostCredits);
            Console.WriteLine($"RTP Value: {RTP}%");
        }

        public int CalculateNetWinLoss(int totalWon, int totalLost)
        {
            return totalWon - totalLost;
        }

        public int NewRound(Random rnd)
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

        public IBall PickBall(Random rnd)
        {
            var index = rnd.Next(0, _balls.Count);
            return _balls[index];
        }

        public void Simulate(ref int winAmount, ref int looseAmount, Random rnd)
        {
            looseAmount += CostOfNewRound;
            var result = NewRound(rnd);

            while (result == 3)
            {
                result = NewRound(rnd);
            }

            if (result == 1)
            {
                winAmount += CreditsOnWin;
            }
        }
    }
}
