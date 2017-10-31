using System.Linq;
using ConsoleCalculator.Expression;
using ConsoleCalculator.Node;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleCalculator.Test
{
    [TestClass]
    public class ChainBuilderTest
    {
        [TestMethod]
        public void BuildTest()
        {
            string input = "5 - 3 / 2 + 7";

            IChainBuilder builder = new ChainBuilder();

            var firstChain = new Chain(5, 3, new SubtractionOperator());
            var secondChain = new Chain(3, 2, new DivisionOperator());
            var thirdChain = new Chain(2, 7, new AdditionOperator());

            var exprectedResult = new[] {firstChain, secondChain, thirdChain};

            var result = builder.CreateChain(input).ToArray();

            Assert.AreEqual(exprectedResult.Length, result.Length);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i].Evaluate(), exprectedResult[i].Evaluate());
                Assert.AreEqual(result[i].Operator.GetType(), exprectedResult[i].Operator.GetType());
            }
        }
    }
}
