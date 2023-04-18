using Data;

namespace DataTest;

[TestClass]
public class WindowTest
{
    [TestMethod]
    public void TestConstructor()
    {
        int width = 800;
        int height = 600;
        WindowAPI window = WindowAPI.CreateWindow(width, height);

        Assert.AreEqual(width, window.Width);
        Assert.AreEqual(height, window.Height);
    }
}