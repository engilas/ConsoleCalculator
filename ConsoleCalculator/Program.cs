using System;
using ConsoleCalculator.Expression;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IChainBuilder chainBuilder = new ChainBuilder();
            ICalculator calculator = new ExpressionCalculator(chainBuilder);

            while (true)
            {
                Console.WriteLine("Input expression:");
                var input = Console.ReadLine();

                try
                {
                    var result = calculator.GetResult(input);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + ": " + ex.InnerException.Message);
                }
            }
        }
    }
}
