using ConsoleCalculator.Expression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleCalculator.Test
{
    [TestClass]
    public class ExpressionCalculatorTest
    {
        [TestMethod]
        public void CalculateExpressionTest()
        {
            var inputString = "-5 + 4/2 - 1 + 3.13 - 7.6*6.1/2 - 8";

            IChainBuilder builder = new ChainBuilder();
            ICalculator calculator = new ExpressionCalculator(builder);

            var result = calculator.GetResult(inputString);

            Assert.AreEqual(result, -32.05);

        }
    }
}
