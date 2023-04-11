using Dane;

namespace Testy
{
    [TestClass]
    public class BallTest
    {
        Ball ball = new Ball(1, 2, 3, 4);

        [TestMethod]
        public void GetterTest()
        {
            Assert.AreEqual(1, ball.X);
            Assert.AreEqual(2, ball.Y);
            Assert.AreEqual(3, ball.SpeedX);
            Assert.AreEqual(4, ball.SpeedY);
        }

        [TestMethod]
        public void SetterTest()
        {
            ball.X = 11;
            ball.Y = 22;
            ball.SpeedX = 33;
            ball.SpeedY = 44;

            Assert.AreEqual(11, ball.X);
            Assert.AreEqual(22, ball.Y);
            Assert.AreEqual(33, ball.SpeedX);
            Assert.AreEqual(44, ball.SpeedY);
        }

        [TestMethod]
        public void MoveTest()
        {
            ball.Move();

            Assert.AreEqual(4, ball.X);
            Assert.AreEqual(6, ball.Y);
        }
    }
}