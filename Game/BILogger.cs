using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Business Intelligence logger. Used to calculate, fetch and run simulations
    /// for statistics about the games.
    /// </summary>
    public class BILogger
    {
        public double CalculateRTP(double win, double loss)
        {
            return Math.Round((win / loss) * 100, 2);
        }

        public void SimulateGame(IGame game, int noOfRounds)
        {
            int wonCredits = 0, lostCredits = 0;
            var rnd = new Random();

            Console.WriteLine($"Sumulating {noOfRounds} rounds");
            for (int round = 1; round <= noOfRounds; round++)
            {
                Console.Write(".");
                game.Simulate(ref wonCredits, ref lostCredits, rnd);
            }
            Console.WriteLine(" ");

            var RTP = CalculateRTP(wonCredits, lostCredits);

            Console.WriteLine($"Simulation finished. Total rounds simulated: {noOfRounds}");
            Console.WriteLine($"Calculated RTP based on simulated rounds is {RTP} %");
        }
    }
}