using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleCalculator.Node;

namespace ConsoleCalculator.Expression
{
    public class ExpressionCalculator : ICalculator
    {
        private readonly IChainBuilder _chainBuilder;

        public ExpressionCalculator(IChainBuilder chainBuilder)
        {
            _chainBuilder = chainBuilder;
        }

        public double GetResult(string input)
        {
            input = input.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Input string is empty!");

            try
            {
                var chains = _chainBuilder.CreateChain(input).ToList();
                if (chains.Any())
                    return CalculateChain(chains);
                else throw new Exception("Can't find any expression");
            }
            catch (Exception ex)
            {
                throw new Exception("Error on expression calculation", ex);
            }
        }

        private double CalculateChain(List<Chain> chains)
        {
            var multiplicativeChains =
                chains.Where(x => x.Operator is MultiplicationOperator || x.Operator is DivisionOperator).ToList();

            double lastValue = 0;

            foreach (var chain in multiplicativeChains)
            {
                lastValue = chain.Evaluate();
                chain.UpdateNeighbors();
                chains.Remove(chain);
            }

            foreach (var chain in chains)
            {
                lastValue = chain.Evaluate();
                chain.UpdateNeighbors();
            }

            return lastValue;
        }
    }
}
