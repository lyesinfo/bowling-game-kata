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
        public void Play_RoundOne_ReturnScore()
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
        public void Play_RoundTwo_ReturnScore()
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
        public void Play_RoundFour_ReturnFrameNumber()
        {
            //Arrange
            int expected = 5;
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
            int expectedFrame2 = 9;
            int expectedFrame3 = 5;
            int expectedFrame4 = 9;
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
        [Test]
        public void Play_RoundFourWithSpare_ReturnScore()
        {
            //Arrange
            int expected = 38;
            //Act
            game.Played(1);
            game.Played(4);
            game.Played(4);
            game.Played(5);
            game.Played(6);
            game.Played(4);
            game.Played(5);
            game.Played(4);
            int actual = game.Score;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Play_GetAStrike_ReturnScore()
        {
            //Arrange
            int expected = 33;
            //Act
            game.Played(1);
            game.Played(4);

            game.Played(10);

            game.Played(5);
            game.Played(4);
           
            int actual = game.Score;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Play_NineStrikes_PerfectScoreMinusOne()
        {
            //Arrange
            int expected = 299;
            //Act
            for (int i = 0; i < 11; i++)
            {
                game.Played(10);
            }
            game.Played(9);

            int actual = game.Score;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Play_PerfectGame_PerfectScore()
        {
            //Arrange
            int expected = 300;
            //Act
            for (int i = 0; i < 12; i++)
            {
                game.Played(10);
            }

            int actual = game.Score;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Play_TwoStrikes_GetScore()
        {
            //Arrange
            int expected = 58;
            //Act
            game.Played(1);
            game.Played(4);

            game.Played(10);

            game.Played(10);

            game.Played(5);
            game.Played(4);

            int actual = game.Score;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}