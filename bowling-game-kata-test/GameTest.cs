using bowling_game_kata;
using NUnit.Framework;

namespace bowling_game_kata_test
{
    public class GameTest
    {
        private Game game;
        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void StartGmae_RoundOne_ReturnScore()
        {
            //Arrange
            int expected = 7;
            //Act
            game.Played(5);
            game.Played(2);
            int actual = game.Score;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void StartGmae_RoundTwo_ReturnScore()
        {
            //Arrange
            int expected = 14;
            //Act
            game.Played(1);
            game.Played(4);
            game.Played(4);
            game.Played(5);
            int actual = game.Score;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void StartGmae_RoundFour_ReturnFrameNumber()
        {
            //Arrange
            int expected = 4;
            //Act
            game.Played(1);
            game.Played(4);
            game.Played(4);
            game.Played(5);
            game.Played(1);
            game.Played(4);
            game.Played(4);
            game.Played(5);
            int actual = game.CurrentFrame;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Play_RoundFour_ReturnScoreByFrame()
        {
            //Arrange
            int expectedFrame1 = 5;
            int expectedFrame2 = 14;
            int expectedFrame3 = 19;
            int expectedFrame4 = 28;
            //Act
            game.Played(1);
            game.Played(4);
            game.Played(4);
            game.Played(5);
            game.Played(1);
            game.Played(4);
            game.Played(4);
            game.Played(5);
            int actualFrame1 = game.GetScoreByFrame(1);
            int actualFrame2 = game.GetScoreByFrame(2);
            int actualFrame3 = game.GetScoreByFrame(3);
            int actualFrame4 = game.GetScoreByFrame(4);
            //Assert
            Assert.AreEqual(expectedFrame1, actualFrame1);
            Assert.AreEqual(expectedFrame2, actualFrame2);
            Assert.AreEqual(expectedFrame3, actualFrame3);
            Assert.AreEqual(expectedFrame4, actualFrame4);
        }
    }
}