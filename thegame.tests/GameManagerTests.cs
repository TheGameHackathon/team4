using System;
using FluentAssertions;
using NUnit.Framework;
using thegame.Services;

namespace Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        private GameManager games;
        private Guid newGuidGame;

        [SetUp]
        public void SetUp()
        {
            games = new GameManager();
        }

        [Test]
        public void AddToGameManager_ReturnGuid()
        {
            var guid = games.AddGame(1);
            Assert.IsNotNull(guid);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CalcWidthBeLevenCorrect(int level)
        {
            newGuidGame = games.AddGame(level);
            Assert.IsTrue(5 * level == games.GetGameById(newGuidGame).Width);
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CalcHeightBeLevenCorrect(int level)
        {
            newGuidGame = games.AddGame(level);
            Assert.IsTrue(3 * level == games.GetGameById(newGuidGame).Height);
        }

        [Test]
        public void GetGameByNonExistentKey_ReturnNull()
        {
            Assert.IsNull(games.GetGameById(Guid.NewGuid()));
        }
    }
}