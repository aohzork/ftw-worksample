using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BILogger
    {
        public double CalculateRTP(double win, double loss)
        {
            return Math.Round((win / loss) * 100, 2);
        }
    }
}
