using System.Collections.Generic;
using ConsoleCalculator.Node;

namespace ConsoleCalculator.Expression
{
    public interface IChainBuilder
    {
        IEnumerable<Chain> CreateChain(string input);
    }
}