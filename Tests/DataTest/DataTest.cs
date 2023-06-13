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
        int number = 2;
        BallAPI ball = BallAPI.CreateBall(x, y, radius, number);

        Assert.AreEqual(x, ball.X);
        Assert.AreEqual(y, ball.Y);
        Assert.AreEqual(radius, ball.Radius);
        Assert.AreEqual(number, ball.Number);
        Assert.AreEqual(diameter, ball.Diameter);
    }

    [TestMethod]
    public void SetterTest()
    {
        double x = 5;
        double y = 10;
        double radius = 2;
        int number = 2;
        BallAPI ball = BallAPI.CreateBall(x, y, radius, number);

        double newX = 10;
        double newY = 20;
        ball.X = newX;
        ball.Y = newY;
        
        Assert.AreEqual(newX, ball.X);
        Assert.AreEqual(newY, ball.Y);
    }
    
    [TestMethod]
    public void MoveTest()
    {
        double x = 5;
        double y = 10;
        double radius = 2;
        int number = 2;
        BallAPI ball = BallAPI.CreateBall(x, y, radius, number);

        ball.VelX = 10;
        ball.VelY = 10;
        ball.Move();
        
        Assert.AreEqual(ball.X, 15);
        Assert.AreEqual(ball.Y, 20);
    }
}