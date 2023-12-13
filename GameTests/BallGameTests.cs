using Game;
using Moq;


namespace GameTests
{
    public class BallGameTests
    {
        [Fact]
        public void PickBall_ReturnsCorrectBall()
        {
            // Arrange
            var balls = new List<IBall>
            {
                new Ball().Clone(BallType.Win),
                new Ball().Clone(BallType.NoWin),
                new Ball().Clone(BallType.ExraPick),
            };

            var game = new BallGame(balls);

            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(0, balls.Count)).Returns(1);

            // Act
            var pickedBall = game.PickBall(randomMock.Object);

            // Assert
            Assert.Equal(BallType.NoWin, pickedBall.Type);
        }

        [Theory]
        [InlineData(BallType.Win, 1)]
        [InlineData(BallType.NoWin, 2)]
        [InlineData(BallType.ExraPick, 3)]
        public void NewRound_ReturnExpectedResult(BallType type, int expectedResult)
        {
            //Arrange
            var game = new BallGame(new List<IBall> { new Ball().Clone(type) });

            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(0, 1)).Returns(0);

            //Act
            var result = game.NewRound(randomMock.Object);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(100,50,50)]
        [InlineData(50,100,-50)]
        public void CalculateNetWinLoss_EnsureCorrectValue(int winAmnt, int lossAmnt, int expectedResult)
        {
            // Arrange
            var game = new BallGame(new List<IBall>());

            //Arrange
            var result = game.CalculateNetWinLoss(winAmnt, lossAmnt);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("y")] // Test the case where the user enters "y"
        [InlineData("n")] // Test the case where the user enters "n"
        public void ValidateInput_ReturnsValidInput(string userInput)
        {
            // Arrange
            var ballGame = new BallGame(new List<IBall>());

            // Act
            var result = ballGame.ValidateInput(userInput);

            // Assert
            Assert.Equal(userInput, result);
        }
    }
}