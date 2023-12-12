using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        private int _credits;
        public Player(int initialCredits)
        {
            _credits = initialCredits;
        }

        public void AddCredits(int credits)
        {
            _credits += credits;
            Console.WriteLine($"+{credits} Credits added , current credits: {_credits} ");
        }

        public bool CanPlayRound(int costOfRound)
        {
            if (_credits - costOfRound < 0) 
            {
                Console.WriteLine("Cannot play due to insufficient funds. Please refill funds");
                return false;
            }

            return true;
        }

        public void SubtractCredits(int credits)
        {
            _credits -= credits;
            Console.WriteLine($"+{credits} Credits subtracted , current credits: {_credits} ");
        }

        public int GetBalance()
        {
            return _credits;
        }
    }
}
