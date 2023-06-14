using QuadEqWithInputVal;

namespace TestQuadSolution
{
    [TestClass]
    public class UnitTest1
    {
        // Test for two-solution case: 1st solution:
        [TestMethod]
        public void Test1()
        {
            (float, float) returnedValue;
            (float, float) expectedValue = (-0.7F, -1.0F);
            float a = 3.0F;
            float b = 5.1F;
            float c = 2.1F;
            returnedValue = Calculate.QuadResult(a, b, c);
            Assert.AreEqual(0.0F, Math.Round(returnedValue.Item1 - expectedValue.Item1, 4));
        }

        // Test for two-solution case: 2nd solution:
        [TestMethod]
        public void Test2()
        {
            (float, float) returnedValue;
            (float, float) expectedValue = (-0.7F, -1.0F);
            float a = 3.0F;
            float b = 5.1F;
            float c = 2.1F;
            returnedValue = Calculate.QuadResult(a, b, c);
            Assert.AreEqual(0.0F, Math.Round(returnedValue.Item2 - expectedValue.Item2, 4));
        }

        // Test, if solution exists; in this case it does:
        [TestMethod]
        public void Test3()
        {
            bool returnedValue;
            bool expectedValue = true;
            float a = 1.0F;
            float b = 3.0F;
            float c = 2.0F;
            returnedValue = SolvableYesNo.Solvable(a, b, c);
            Assert.AreEqual(returnedValue, expectedValue);
        }

        // Test, if solution exists; in this case it does not:
        [TestMethod]
        public void Test4()
        {
            bool returnedValue;
            bool expectedValue = false;
            float a = 0.85F;
            float b = 2.5F;
            float c = 2.0F;
            returnedValue = SolvableYesNo.Solvable(a, b, c);
            Assert.AreEqual(returnedValue, expectedValue);
        }

        // Test the case when only one solution exists:
        [TestMethod]
        public void Test5()
        {
            float returnedValue;
            float expectedValue = -1.0F;
            float a = 2.0F;
            float b = 4.0F;
            float c = 2.0F;
            returnedValue = Calculate.SingleResult(a, b, c);
            Assert.AreEqual(returnedValue, expectedValue);
        }
    }
}