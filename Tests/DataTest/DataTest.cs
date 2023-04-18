using Data;

namespace DataTest;

[TestClass]
public class DataTest
{
    [TestMethod]
    public void TestConstructor()
    {
        double x = 5;
        double y = 10;
        double radius = 2;
        double diameter = radius * 2;
        BallAPI ball = BallAPI.CreateBall(x, y, radius);

        Assert.AreEqual(x, ball.X);
        Assert.AreEqual(y, ball.Y);
        Assert.AreEqual(radius, ball.Radius);
        Assert.AreEqual(diameter, ball.Diameter);
    }

    [TestMethod]
    public void SetterTest()
    {
        double x = 5;
        double y = 10;
        double radius = 2;
        BallAPI ball = BallAPI.CreateBall(x, y, radius);

        double newX = 10;
        double newY = 20;
        ball.X = newX;
        ball.Y = newY;
        
        Assert.AreEqual(newX, ball.X);
        Assert.AreEqual(newY, ball.Y);
    }
}