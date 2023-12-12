using Game;

namespace GameTests
{
    public class PlayerTests
    {
        [Fact]
        public void AddCredits_ShouldIncreaseCredits()
        {
            //Arrange
            var player = new Player(100);

            //Act
            player.AddCredits(10);

            //Assert
            Assert.Equal(110, player.GetBalance());
        }

        [Fact]
        public void SubtractCredits_ShouldDecreseCredits()
        {
            //Arrange
            var player = new Player(100);

            //Act
            player.SubtractCredits(10);

            //Assert
            Assert.Equal(90, player.GetBalance());
        }

        [Theory]
        [InlineData(100,50, true)]
        [InlineData(50,100, false)]
        public void CanPlayRound_ShouldReturnCorrect(int initialCredits, int costOfRound, bool expectedResult)
        {
            //Arrange
            var player = new Player(initialCredits);

            //Act
            var result = player.CanPlayRound(costOfRound);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
