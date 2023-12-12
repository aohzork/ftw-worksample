using Game;
using Moq;

namespace GameTests
{
    public class InitBallGamplayTests
    {
        [Fact]
        public void AddCorrectNumberOfBallsNoOptional()
        {
            //Arrange
            var mockBall = new Mock<IBall>();
            mockBall.Setup(b => b.Type).Returns(BallType.Win);

            //Act
            var initBallGameplay = new InitBallGamplay(5, 5, mockBall.Object);

            //Assert
            Assert.Equal(10, initBallGameplay.GetBalls().Count);
        }

        [Fact]
        public void AddCorrectNumberOfBallsWithOptional()
        {
            //Arrange
            var mockBall = new Mock<IBall>();
            mockBall.Setup(b => b.Type).Returns(BallType.Win);

            //Act
            var initBallGameplay = new InitBallGamplay(5, 5, mockBall.Object, 5);

            //Assert
            Assert.Equal(15, initBallGameplay.GetBalls().Count);
        }

        [Fact]
        public void AddBallsWithCorrectType()
        {
            //Act
            var initBallGameplay = new InitBallGamplay(2, 10, new Ball(), 5);

            //Assert
            Assert.Equal(2, initBallGameplay.GetBalls().Where(b => b.Type == BallType.Win).Count());
            Assert.Equal(10, initBallGameplay.GetBalls().Where(b => b.Type == BallType.NoWin).Count());
            Assert.Equal(5, initBallGameplay.GetBalls().Where(b => b.Type == BallType.ExraPick).Count());
        }
    }
}