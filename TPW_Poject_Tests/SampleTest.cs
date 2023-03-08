namespace TPW_Poject_Tests
{
    using TPW_Project;
    [TestClass]
    public class SampleTest
    {
        [TestMethod]
        public void GetValue_ReturnsValue()
        {
            int testValue = 5;
            SampleClass sample = new(testValue);

            int result = sample.GetValue();

            Assert.AreEqual(testValue, result);
        }
    }
}