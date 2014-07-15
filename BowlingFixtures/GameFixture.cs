using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling;

namespace BowlingFixtures
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void AllStrikes()
        {
            Game g = new Game();
            for (int i = 0; i < 12; i++)
            {
                g.Roll(10);
            }
            Assert.AreEqual(300, g.GetScore());
        }

        [TestMethod]
        public void NoStrikeOrSpare()
        {
            Game g = new Game();
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);
            g.Roll(0);
            g.Roll(3);

            Assert.AreEqual(30, g.GetScore());
        }

        [TestMethod]
        public void StrikeOrSpareInBetween()
        {
            Game g = new Game();
            g.Roll(7);
            g.Roll(3);
            
            g.Roll(2);
            g.Roll(5);
            
            g.Roll(6);
            g.Roll(2);
            
            g.Roll(0);
            g.Roll(7);

            g.Roll(3);
            g.Roll(7);

            g.Roll(6);
            g.Roll(2);

            g.Roll(3);
            g.Roll(2);
            
            g.Roll(6);
            g.Roll(2);

            g.Roll(10);

            g.Roll(0);
            g.Roll(0);
            Assert.AreEqual(81, g.GetScore());
        }

        [TestMethod]
        public void SpareAtLast()
        {
            Game g = new Game();
            g.Roll(7);
            g.Roll(3);

            g.Roll(2);
            g.Roll(5);

            g.Roll(6);
            g.Roll(2);

            g.Roll(0);
            g.Roll(7);

            g.Roll(3);
            g.Roll(7);

            g.Roll(6);
            g.Roll(2);

            g.Roll(3);
            g.Roll(2);

            g.Roll(6);
            g.Roll(2);

            g.Roll(10);

            g.Roll(7);
            g.Roll(3);

            g.Roll(4);
            Assert.AreEqual(105, g.GetScore());
        }

        [TestMethod]
        public void AllGutters()
        {
            Game g = new Game();
            for (int i = 0; i < 10; i++)
            {
                g.Roll(0);
            }
            Assert.AreEqual(0, g.GetScore());
        }

        [TestMethod]
        public void StrikeAtLast()
        {
            Game g = new Game();
            g.Roll(7);
            g.Roll(3);

            g.Roll(2);
            g.Roll(5);

            g.Roll(6);
            g.Roll(2);

            g.Roll(0);
            g.Roll(7);

            g.Roll(3);
            g.Roll(7);

            g.Roll(6);
            g.Roll(2);

            g.Roll(3);
            g.Roll(2);

            g.Roll(6);
            g.Roll(2);

            g.Roll(7);
            g.Roll(2);

            g.Roll(10);

            g.Roll(4);
            g.Roll(6);

            Assert.AreEqual(100, g.GetScore());
        }

    }
}
