using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace GameTests
{
    public class BILoggerTests
    {
        [Fact]
        public void CalculateRTP_LossGreaterThenWin_EnsureCorrectValue()
        {
            //Arrange
            var logger = new BILogger();

            //Act
            var result = logger.CalculateRTP(100, 150);

            //Assert
            Assert.Equal(66,67, result);
        }

        [Fact]
        public void CalculateRTP_WinGreaterThenLoss_EnsureCorrectValue()
        {
            //Arrange
            var logger = new BILogger();

            //Act
            var result = logger.CalculateRTP(150, 100);

            //Assert
            Assert.Equal(150, result);
        }
    }
}
