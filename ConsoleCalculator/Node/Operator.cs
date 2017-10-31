namespace ConsoleCalculator.Node
{
    public interface IOperator
    {
        double Calculate(double value1, double value2);
    }

    public class MultiplicationOperator : IOperator
    {
        public double Calculate(double value1, double value2) => value1 * value2;
    }

    public class DivisionOperator : IOperator
    {
        public double Calculate(double value1, double value2) => value1 / value2;
    }

    public class AdditionOperator : IOperator
    {
        public double Calculate(double value1, double value2) => value1 + value2;
    }

    public class SubtractionOperator : IOperator
    {
        public double Calculate(double value1, double value2) => value1 - value2;
    }

}
